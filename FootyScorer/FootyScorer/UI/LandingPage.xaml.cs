using System;
using FootyScorer.Constants;
using Xamarin.Forms;

namespace FootyScorer.UI
{
    public partial class LandingPage : FootyScorerContentPageBase
    {
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

            GameTapped.Tapped += HandleGameTapped;
            GameTapped2.Tapped += HandleGameTapped;
            GameTapped3.Tapped += HandleGameTapped;
            GameTapped1.Tapped += HandleGameTapped;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            GameTapped.Tapped -= HandleGameTapped;
            GameTapped1.Tapped -= HandleGameTapped;
            GameTapped2.Tapped -= HandleGameTapped;
            GameTapped3.Tapped -= HandleGameTapped;
        }

        private void HandleGameTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MatchHistory());
        }
    }
}
