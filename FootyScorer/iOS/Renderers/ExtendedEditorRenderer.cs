using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using FootyScorer.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Editor), typeof(ExtendedEditorRenderer))]

namespace FootyScorer.iOS.Renderers
{
	public class ExtendedEditorRenderer : EditorRenderer
	{
		// The next element. Can be null.
		private InputView NextElement { get; set; }
		private InputView PrevElement { get; set; }

		private UIBarButtonItem _backButton;
		private UIBarButtonItem _forwardButton;

		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

			_backButton = new UIBarButtonItem(UIImage.FromBundle("icn_arrow_up.png"), UIBarButtonItemStyle.Plain, PreviousButtonPressed);

			_forwardButton = new UIBarButtonItem(UIImage.FromBundle("icn_arrow_down.png"), UIBarButtonItemStyle.Plain, NextButtonPressed);

			toolbar.Items = new[]
			{
				_backButton,
				_forwardButton,
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
				new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
			};

			Control.InputAccessoryView = toolbar;
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
								NextElement = entries.ElementAt(focused);
								_forwardButton.Enabled = true;
							}
							else
								_forwardButton.Enabled = false;

							focused = getFocusedIndex() - 1;
							if (focused >= 0)
							{
								PrevElement = entries.ElementAt(focused);
								_backButton.Enabled = true;
							}
							else
								_backButton.Enabled = false;
						}
						else
						{
							_forwardButton.Enabled = false;
							_backButton.Enabled = false;
						}
					}
				}
			}
			base.OnElementPropertyChanged(sender, e);

		}

		private void PreviousButtonPressed(object sender, EventArgs e)
		{
			PrevElement?.Focus();
		}

		private void NextButtonPressed(object sender, EventArgs e)
		{
			NextElement?.Focus();
		}

		private List<InputView> GetChildren(IViewContainer<Xamarin.Forms.View> element)
		{
			var children = new List<InputView>();
			foreach (var child in element.Children)
			{
				var view = child as IViewContainer<Xamarin.Forms.View>;
				if (view != null)
					children.AddRange(GetChildren(view));

				var control = child as InputView;
				if (control == null) continue;

				if (control.IsEnabled && control.IsVisible)
					children.Add(control);
			}
			return children;
		}
	}
}
