using FormsPlugin.Iconize;
using Xamarin.Forms;

namespace FootyScorer.UI.Controls
{
    public class MatchCell : ViewCell
    {
        public MatchCell()
        {
            var roundLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                FontAttributes = FontAttributes.Bold,
                FontSize = 10,
                Text = "Round"
            };

            var roundNumber = new Label
            {
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				FontAttributes = FontAttributes.Bold,
				FontSize = 15
            };

            roundNumber.SetBinding(Label.TextProperty, "RoundNumber");

            var roundStack = new StackLayout
            {
                Spacing = 0,
                Padding = 0,
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = 
                {
                    roundLabel,
                    roundNumber
                }
            };

            var teamsLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 14,
                LineBreakMode = LineBreakMode.WordWrap
            };

            teamsLabel.SetBinding(Label.TextProperty, "VersingTeams");

			var scoreLabel = new Label
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 14,
				LineBreakMode = LineBreakMode.WordWrap
			};

			scoreLabel.SetBinding(Label.TextProperty, "ShortTotalScore");

			var detailStack = new StackLayout
			{
				Spacing = 0,
				Padding = 10,
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Children =
				{
					teamsLabel,
					//scoreLabel
				}
			};

            var disclosureIndicator = new IconLabel
            {
                FontSize = 26,
                Text = "fa-angle-right",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var layout = new RelativeLayout { HeightRequest = 65 };

            layout.Children.Add(roundStack,
				Constraint.Constant(0), // x
				Constraint.Constant(0),
	            Constraint.Constant(65),
	            Constraint.RelativeToParent(cell => cell.Height));

            layout.Children.Add(detailStack,
                Constraint.Constant(65), // x
                Constraint.Constant(0), // y
                Constraint.RelativeToParent(cell => (cell.Width- 30 - 65)), // width
                Constraint.RelativeToParent(cell => cell.Height)); // height);

            layout.Children.Add(disclosureIndicator,
               Constraint.RelativeToParent(c => c.Width - 30),
               Constraint.Constant(0),
               Constraint.Constant(30),
               Constraint.Constant(65));

            View = layout;
        }
    }
}
