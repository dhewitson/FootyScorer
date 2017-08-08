using System;
using System.Linq;
using System.Collections.Generic;
using FootyScorer.Constants;
using FootyScorer.UI.Controls;
using FootyScorer.ViewModel;
using Xamarin.Forms;
using FootyScorer.UI.Match;

namespace FootyScorer.UI
{
    public partial class LandingPage : FootyScorerContentPageBase, IDisposable
    {
        private List<MatchViewModel> _matches;
        private MatchListPage _viewMoreListPage;
        private NewMatch _newMatch;

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

			_newMatch?.Dispose();
			_viewMoreListPage?.Dispose();
			_viewMoreListPage = null;
			_newMatch = null;

            _matches = App.DataManager.GetMatches((m) => true).OrderByDescending(m => m.Date).Take(4).ToList();
            BuildGrid();
            ViewMoreGesture.Tapped += ViewMoreTapped;
            StartMatchTapped.Tapped += StartMatchButtonTapped;
		 }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewMoreGesture.Tapped -= ViewMoreTapped;
            StartMatchTapped.Tapped -= StartMatchButtonTapped;
        }

        private void HandleGameTapped(object index)
        {
            var match = _matches[(int)index];
            Navigation.PushAsync(new MatchHistory(match.Id));
        }

        private async void ViewMoreTapped(object sender, EventArgs e)
        {
            _viewMoreListPage = new MatchListPage();
            await Navigation.PushAsync(_viewMoreListPage, true);
        }

        private async void StartMatchButtonTapped(object sender, EventArgs e)
        {
            _newMatch = new NewMatch(App.DataManager.CreateNewMatch());
            await Navigation.PushAsync(_newMatch, true);
        }

        private void BuildGrid()
        {
            MatchesGrid.Children?.Clear();

            int row = 0;
            int column = 0;
            int index = 0;

            NoPreviousMatchesLabel.IsVisible = _matches == null || !_matches.Any();
            ViewMoreStack.IsVisible = !NoPreviousMatchesLabel.IsVisible;

            if (_matches == null) return;

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
							FontSize = 12,
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
							FontSize = 12,
                            Text = $"{m.HomeTeamTotalShort} to {m.AwayTeamTotalShort}",
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

        #region IDisposable Support
        private bool disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    _matches?.Clear();
                    _newMatch?.Dispose();
                    _viewMoreListPage?.Dispose();
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.
                _matches = null;
                _viewMoreListPage = null;
                _newMatch = null;
                disposedValue = true;
            }
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~LandingPage() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}