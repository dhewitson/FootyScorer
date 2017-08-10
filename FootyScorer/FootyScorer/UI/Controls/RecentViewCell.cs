using System;
using FootyScorer.Constants;
using FormsPlugin.Iconize;
using Xamarin.Forms;

namespace FootyScorer.UI.Controls
{
    public class RecentViewCell : ViewCell
    {
        public RecentViewCell()
        {
			
			var homeTeam = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 12,
				FontAttributes = FontAttributes.Bold,
				TextColor = ThemeSettings.DefaultComplementaryColor,
				LineBreakMode = LineBreakMode.WordWrap
			};
			homeTeam.SetBinding(Label.TextProperty, "HomeTeamShort");

			var homeTeamScore = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 12,
				FontAttributes = FontAttributes.Bold,
				TextColor = ThemeSettings.DefaultComplementaryColor,
				LineBreakMode = LineBreakMode.WordWrap
			};
			homeTeamScore.SetBinding(Label.TextProperty, "HomeTeamTotalShort");

			var resultLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 10
			};
            resultLabel.SetBinding(Label.TextProperty, "Result");

			var awayTeamScore = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 12,
				FontAttributes = FontAttributes.Bold,
				TextColor = ThemeSettings.DefaultComplementaryColor,
				LineBreakMode = LineBreakMode.WordWrap
			};
			awayTeamScore.SetBinding(Label.TextProperty, "AwayTeamTotalShort");

			var roundLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 12
			};
			roundLabel.SetBinding(Label.TextProperty, "Round");

			var dateLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 12,
                FontAttributes = FontAttributes.Italic
			};
			dateLabel.SetBinding(Label.TextProperty, "ShortDateText");

			var scoreStack = new StackLayout
			{
				Spacing = 20,
				Padding = 0,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Children =
				{
					homeTeamScore,
                    resultLabel,
                    awayTeamScore
                }
			};

            var detailStack = new StackLayout
            {
                Spacing = 8,
                Padding = 10,
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new StackLayout{
                        Orientation = StackOrientation.Horizontal,
                        Spacing = 0,
                        Padding = 0,
                        Children = {
							roundLabel,
					        dateLabel,
                        }
                    },
                    scoreStack,
                }
            };

			var awayTeam = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                TextColor = ThemeSettings.DefaultComplementaryColor,
				LineBreakMode = LineBreakMode.WordWrap
			};

			awayTeam.SetBinding(Label.TextProperty, "AwayTeamShort");

            var layout = new RelativeLayout();

			layout.Children.Add(homeTeam,
				Constraint.Constant(0), // x
				Constraint.Constant(0),
				Constraint.Constant(65),
				Constraint.RelativeToParent(cell => cell.Height));

			layout.Children.Add(detailStack,
				Constraint.Constant(70), // x
				Constraint.Constant(0), // y
				Constraint.RelativeToParent(cell => (cell.Width - 65 - 65)), // width
				Constraint.RelativeToParent(cell => cell.Height)); // height);

			layout.Children.Add(awayTeam,
			   Constraint.RelativeToParent(c => c.Width - 65),
			   Constraint.Constant(0),
			   Constraint.Constant(65),
			   Constraint.RelativeToParent(cell => cell.Height));

            View = layout;
		}
    }
}
