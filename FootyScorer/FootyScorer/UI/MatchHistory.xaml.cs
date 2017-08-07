using System;
using FootyScorer.Constants;
using Xamarin.Forms;

namespace FootyScorer.UI
{
    public partial class MatchHistory : ContentPage
    {
        public MatchHistory(Guid matchId)
        {
            InitializeComponent();
			Title = "Match Details";
			BackgroundColor = ThemeSettings.DefaultBackgroundColour;

            var model = App.DataManager.GetMatch((m) => m.Id == matchId);
            BindingContext = model;
        }
    }
}
