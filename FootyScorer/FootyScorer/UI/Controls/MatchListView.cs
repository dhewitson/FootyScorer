using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FootyScorer.Constants;
using FootyScorer.Data;
using FootyScorer.ViewModel;
using Xamarin.Forms;

namespace FootyScorer.UI.Controls
{
    public class MatchListView : ListView, IDisposable
    {
        public IEnumerable<MatchViewModel> MatchesFiltered;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FootyScorer.UI.Controls.MatchListView"/> class.
        /// </summary>
        public MatchListView() : base(ListViewCachingStrategy.RecycleElement)
        {
            ItemsSource = MatchesFiltered;

            ItemSelected += (s, e) =>
            {
                if (SelectedItem == null)
                    return;

                SelectedItem = null;
            };
            SeparatorColor = ThemeSettings.ListViewSeparatorColor;
            HasUnevenRows = true;
            GroupHeaderTemplate = new DataTemplate(typeof(DateGroupHeaderCell));
            IsPullToRefreshEnabled = false;
        }

        public void FilterActivities(string filter, IEnumerable<MatchViewModel> matches)
        {
            if (string.IsNullOrWhiteSpace(filter))
                MatchesFiltered = matches;
            else
            {
                var matchesViewModels = matches as IList<MatchViewModel> ?? matches.ToList();
                MatchesFiltered =
					new ObservableCollection<MatchViewModel>(matchesViewModels.Where(x => x.Round.ToLower()
					   .Contains(filter.ToLower())).ToList().Union(matchesViewModels.Where(x => x.HomeTeam.ToLower()
							   .Contains(filter.ToLower())).ToList().Union(matchesViewModels.Where(x => x.AwayTeam.ToLower()
									   .Contains(filter.ToLower())).ToList().Union(matchesViewModels.Where(x => x.CompetitionName.ToLower()
											.Contains(filter.ToLower())).ToList()))));
            }

            var grouped = MatchesFiltered.OrderByDescending(a => a.Date).GroupBy(x => x.Date.ToString("D")).Select(
                                matchesGroup => new Grouping<string, MatchViewModel>(matchesGroup.Key, matchesGroup));


            var activitiesGrouped = new ObservableCollection<Grouping<string, MatchViewModel>>(grouped);
            ItemsSource = activitiesGrouped;
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
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.
                MatchesFiltered = null;
                disposedValue = true;
            }
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MatchListView() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}