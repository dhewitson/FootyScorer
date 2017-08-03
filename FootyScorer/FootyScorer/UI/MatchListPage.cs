using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FootyScorer.UI
{
    public class MatchListPage : ContentPage
    {
        private ListView _listView;

        public MatchListPage()
        {
            BuildLayout();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Task.Run(() => RefreshData());
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void BuildLayout()
        {
            
        }

        private void RefreshData()
        {
            
        }
    }
}

