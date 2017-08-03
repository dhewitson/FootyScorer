using System;
using System.Collections.Generic;
using System.Linq;
using Android.Views.InputMethods;
using Android.Widget;
using FootyScorer.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(ExtendedEntryRenderer))]
namespace FootyScorer.Droid.Renderers
{
	public class ExtendedEntryRenderer : EntryRenderer
	{
		protected InputView NextElement { get; set; }

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			//Unhooked in dispose
			Control.EditorAction += HandleNextAction;
		}

		private void HandleNextAction(object sender, TextView.EditorActionEventArgs e)
		{
			e.Handled = false;
			if (e.ActionId != ImeAction.Next || NextElement == null) return;

			NextElement?.Focus();
			e.Handled = true;
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
						if (parent.Parent is IViewContainer<Xamarin.Forms.View>)
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
								Control.ImeOptions = ImeAction.Next;
								Control.SetImeActionLabel("Next", ImeAction.Next);
								//if (Control.ImeActionId == (int) ImeAction.Next)
								NextElement = entries.ElementAt(focused);
							}
							else
							{
								NextElement = null;
								Control.SetImeActionLabel("Done", ImeAction.Done);
							}
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
