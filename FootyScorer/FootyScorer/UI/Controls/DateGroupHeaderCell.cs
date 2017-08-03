using System;
using FootyScorer.Constants;
using Xamarin.Forms;

namespace FootyScorer.UI.Controls
{
    public class DateGroupHeaderCell : ViewCell
	{
		public DateGroupHeaderCell()
		{
			var groupHeaderLabel = new Label
			{
				VerticalOptions = LayoutOptions.Center,
			};

			groupHeaderLabel.SetBinding(Label.TextProperty, new Binding("Key"));

			var viewLayout = new StackLayout
			{
				BackgroundColor = ThemeSettings.ListViewSeparatorColor,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Spacing = 0,
				Children = { groupHeaderLabel }
			};

			if (Device.RuntimePlatform == Device.iOS)
			{
				viewLayout.Padding = new Thickness(5, 0, 0, 0);
				Height = 27;
			}
			else
				viewLayout.Padding = new Thickness(5, 2, 0, 2);


			View = viewLayout;
		}
	}
}
