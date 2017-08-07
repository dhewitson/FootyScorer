using System;
using System.Linq;
using System.Collections.Generic;
using FootyScorer.Constants;
using FootyScorer.UI.Controls;
using FootyScorer.ViewModel;
using Xamarin.Forms;

namespace FootyScorer.UI
{
    public partial class LandingPage : FootyScorerContentPageBase
    {
        private List<MatchViewModel> _matches;

        public LandingPage()
        {
            InitializeComponent();
            Title = StringResource.ApplicationName;
            BackgroundColor = ThemeSettings.DefaultBackgroundColour;

            NavigationPage.SetHasNavigationBar(this, true);
            //NavigationPage.SetTitleIcon(this, "");
            NavigationPage.SetBackButtonTitle(this, StringResource.BackLabel);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _matches = App.DataManager.GetMatches((m) => true).OrderByDescending(m => m.Date).Take(4).ToList();
            BuildGrid();
		 }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void HandleGameTapped(object index)
        {
            var match = _matches[(int)index];
            Navigation.PushAsync(new MatchHistory(match.Id));
        }

        private void BuildGrid()
        {
            MatchesGrid.Children?.Clear();

            int row = 0;
            int column = 0;
            int index = 0;

            foreach (var m in _matches)
            {
				var boxView = new RoundedBoxView
				{
					CornerRadius = 45,
					Color = Color.White,
					Stroke = ThemeSettings.DefaultSplitComplementaryColor,
					StrokeThickness = 2
				};
				var stack = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Fill,
					Spacing = 5,
					Padding = 0,
					Children =
				    {
						new Label
						{
							FontSize = 10,
							Text = m.Round,
							FontAttributes = FontAttributes.Bold,
							TextColor = Color.Black,
							HorizontalOptions = LayoutOptions.Center,
							HorizontalTextAlignment = TextAlignment.Center,
							VerticalTextAlignment = TextAlignment.Center
						},
						new Label
						{
							FontSize = 10,
							Text = m.VersingTeams,
							TextColor = Color.Black,
							HorizontalOptions = LayoutOptions.Center,
							HorizontalTextAlignment = TextAlignment.Center,
							VerticalTextAlignment = TextAlignment.Center
						},
						new Label
						{
							FontSize = 10,
                            Text = $"{m.HomeTeamTotalShort}   to   {m.AwayTeamTotalShort}",
							FontAttributes = FontAttributes.Bold,
							TextColor = Color.Black,
							HorizontalOptions = LayoutOptions.Center,
							HorizontalTextAlignment = TextAlignment.Center,
							VerticalTextAlignment = TextAlignment.Center
						},
						new Label
						{
							FontSize = 10,
							Text = m.DateText,
							TextColor = Color.Black,
							HorizontalOptions = LayoutOptions.Center,
							HorizontalTextAlignment = TextAlignment.Center,
							VerticalTextAlignment = TextAlignment.Center
						}
					},
					GestureRecognizers =
					{
						new TapGestureRecognizer { Command = new Command(HandleGameTapped), CommandParameter = index}
					}
				};

                MatchesGrid.Children.Add(boxView, column, row);
                MatchesGrid.Children.Add(stack, column, row);

                index++;

                if (column == 1)
                {
                    row++;
                    column = 0;
                }
                else
                    column++;
            }

		}
    }
}
