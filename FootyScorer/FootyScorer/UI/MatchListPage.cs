using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FootyScorer.Constants;
using FootyScorer.UI.Controls;
using FootyScorer.ViewModel;
using Xamarin.Forms;

namespace FootyScorer.UI
{
    public class MatchListPage : ContentPage, IDisposable
    {
        private List<MatchViewModel> _matches;
        private MatchListView _listView;
        private SearchBar _searchbar;

        public MatchListPage()
        {
			Title = StringResource.MatchPageTitle;
			BackgroundColor = ThemeSettings.DefaultBackgroundColour;
            BuildLayout();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_searchbar != null)
            {
                _searchbar.TextChanged += SearchTextChanged;
                _searchbar.SearchButtonPressed += SearchButtonPressed;
            }

            #pragma warning disable CS4014
			Task.Run(() => RefreshData());
            #pragma warning restore CS4014
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

			if (_searchbar != null)
			{
				_searchbar.TextChanged -= SearchTextChanged;
				_searchbar.SearchButtonPressed -= SearchButtonPressed;
			}
        }

        private void BuildLayout()
        {
            _listView = new MatchListView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                ItemTemplate = new DataTemplate(() => new MatchCell()),
                IsPullToRefreshEnabled = false,
                IsRefreshing = IsBusy,
                IsGroupingEnabled = true,
                IsVisible = false,
                RowHeight = 65,
                RefreshCommand = new Command(RefreshData)
            };
            _listView.ItemTapped += HandleItemSelected;

            _searchbar = new SearchBar
            {
                Placeholder = StringResource.FilterLabel,
                BindingContext = this
            };


            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
                Children = {
                    _searchbar,
                    _listView
                }
            };
        }

		private void HandleItemSelected(object sender, ItemTappedEventArgs e)
		{
			var match = e.Item as MatchViewModel;
			if (match == null) return;

			Device.BeginInvokeOnMainThread(async () => { await Navigation.PushAsync(new MatchHistory(match.Id), true); });
		}

		private void SearchButtonPressed(object sender, EventArgs e)
		{
            _listView.FilterActivities(_searchbar.Text, _matches);
		}

		private void SearchTextChanged(object sender, EventArgs e)
		{
            _listView.FilterActivities(_searchbar.Text, _matches);
		}

		private void RefreshData()
        {
            _matches = App.DataManager.GetMatches((m) => true);

            Device.BeginInvokeOnMainThread(() =>
           {
               _listView.ItemsSource = _matches;
               _listView.FilterActivities(_searchbar.Text, _matches);

               _listView.IsRefreshing = false;
               _listView.IsVisible = true;
               _listView.EndRefresh();
           });
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    _matches?.Clear();
                    _listView?.Dispose();
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.
                _searchbar = null;
                _matches = null;
                _listView = null;
                disposedValue = true;
            }
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MatchListPage() {
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

