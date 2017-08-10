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
            //Title = StringResource.ApplicationName;
            BackgroundColor = ThemeSettings.DefaultApplicationColor;

            NavigationPage.SetHasNavigationBar(this, false);
            //NavigationPage.SetTitleIcon(this, "");
            NavigationPage.SetBackButtonTitle(this, StringResource.BackLabel);

            RecentListView.ItemTapped += HandleItemSelected;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _newMatch?.Dispose();
            _viewMoreListPage?.Dispose();
            _viewMoreListPage = null;
            _newMatch = null;

			_matches = App.DataManager.GetMatches((m) => true).OrderByDescending(m => m.Date).Take(4).ToList();


			RecentListView.ItemTemplate = new DataTemplate(() => new RecentViewCell());
            RecentListView.ItemsSource = _matches;
            RecentListView.RowHeight = 60;

            StartMatchTapped.Tapped += StartMatchButtonTapped;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
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

		private void HandleItemSelected(object sender, ItemTappedEventArgs e)
		{
			var match = e.Item as MatchViewModel;
			if (match == null) return;

			Device.BeginInvokeOnMainThread(async () => { await Navigation.PushAsync(new MatchHistory(match.Id), true); });
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