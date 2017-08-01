using System;
using System.Collections.Generic;
using FootyScorer.Constants;
using Xamarin.Forms;

namespace FootyScorer.UI
{
    public partial class LandingPage : FootyScorerContentPageBase
    {
        public LandingPage()
        {
            InitializeComponent();

            BackgroundColor = ThemeSettings.DefaultBackgroundColour;

            NavigationPage.SetHasNavigationBar(this, true);
            //NavigationPage.SetTitleIcon(this, "");
            NavigationPage.SetBackButtonTitle(this, StringResource.BackLabel);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
