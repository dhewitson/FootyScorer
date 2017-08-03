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
    public class MatchListView : ListView
    {

        public IEnumerable<MatchViewModel> MatchesFiltered;

        public MatchListView()
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
                        .Contains(filter.ToLower())).ToList().Union(matchesViewModels.Where(x => x.AwayTeam.ToLower()
                            .Contains(filter.ToLower()))
                            .ToList()));
            }

            var grouped = MatchesFiltered.OrderByDescending(a => a.Date).GroupBy(x => x.Date.ToString("D")).Select(
                                matchesGroup => new Grouping<string, MatchViewModel>(matchesGroup.Key, matchesGroup));


            var activitiesGrouped = new ObservableCollection<Grouping<string, MatchViewModel>>(grouped);
            ItemsSource = activitiesGrouped;
        }
    }
}