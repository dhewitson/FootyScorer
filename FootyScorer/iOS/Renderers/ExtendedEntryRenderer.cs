using System;
using System.Collections.Generic;
using System.Linq;
using FootyScorer.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(ExtendedEntryRenderer))]

namespace FootyScorer.iOS.Renderers
{
	/// <summary>
	/// Extended renderer to apply the "next" and "return/done" buttons on the iOS keyboard.
	/// Logic says, when there is another text entry control on the view, use the "next" button 
	/// and make that button change the focus to that entry. If there are no more entries, 
	/// show the default "return" button and apply the default action for that.
	/// 
	/// NOTE: If there is a need to only apply this to specific entries, we can change
	/// the default export type from "Entry" to a custom type and use that type declaration on the control
	/// in the shared project. You will also need to change all "Entry" references in this class to
	/// the custom type. 
	/// </summary>
	public class ExtendedEntryRenderer : EntryRenderer
	{
		// The next element. Can be null.
		private InputView NextElement { get; set; }

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			Control.ClearButtonMode = UITextFieldViewMode.WhileEditing;

			//Unhooked in dispose
			Control.ShouldReturn += ReturnPressed;
		}

		protected override void Dispose(bool disposing)
		{
			Control.ShouldReturn -= ReturnPressed;
			base.Dispose(disposing);
		}

		public bool ReturnPressed(UITextField textField)
		{
			if (NextElement != null)
			{
				NextElement.Focus();

				if (NextElement is Editor)
					return false;
			}

			return true;
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsFocused")
			{
				if (Element.IsFocused)
				{
					// Navigation logic
					IViewContainer<Xamarin.Forms.View> parentObject = null;
					var parent = Element.Parent;
					while (parent != null)
					{
						if (parent == null)
							break;

						if (parent.Parent != null && parent.Parent is IViewContainer<Xamarin.Forms.View>)
							parent = parent.Parent;
						else
						{
							parentObject = parent as IViewContainer<Xamarin.Forms.View>;
							break;
						}

					}

					if (parentObject != null)
					{
						var entries = GetChildren(parentObject);

						if (entries.Count > 1)
						{
							Func<int> getFocusedIndex = () => entries.Select((v, i) => new
							{
								item = v,
								index = i
							}).Where(w => w.item.IsFocused).Select(s => s.index).Single();

							var focused = getFocusedIndex() + 1;
							focused = focused + 1 > entries.Count ? 0 : focused;
							if (focused > 0)
							{
								Control.ReturnKeyType = UIReturnKeyType.Next;
								NextElement = entries.ElementAt(focused);
							}
							else
								Control.ReturnKeyType = UIReturnKeyType.Done;
						}
					}
				}
			}
			base.OnElementPropertyChanged(sender, e);
		}

		private List<InputView> GetChildren(IViewContainer<Xamarin.Forms.View> element)
		{
			var children = new List<InputView>();
			foreach (var child in element.Children)
			{
				var view = child as IViewContainer<Xamarin.Forms.View>;
				if (view != null)
					children.AddRange(GetChildren(view));
				else if (child is InputView)
				{
					var control = child as InputView;
					if (control.IsEnabled && control.IsVisible)
						children.Add(control);
				}
			}
			return children;
		}
	}
}