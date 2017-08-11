using System;
using System.Linq;
using System.Collections.Generic;
using FootyScorer.Constants;
using FootyScorer.Data.Model;
using FootyScorer.ViewModel;
using Xamarin.Forms;

namespace FootyScorer.UI.Match
{
    public partial class NewMatch : ContentPage, IDisposable
    {
        private MatchViewModel _model;
        private List<Team> _teams;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FootyScorer.UI.Match.NewMatch"/> class.
        /// </summary>
        /// <param name="model">Model.</param>
        public NewMatch(MatchViewModel model)
        {
            InitializeComponent();
            Title = StringResource.NewMatchTitle;
            BackgroundColor = ThemeSettings.DefaultBackgroundColour;

            _model = model;
            _model.CompetitionName = _model.CompetitionName ?? "";
            _model.HomeTeam = _model.HomeTeam ?? "";
            _model.AwayTeam = _model.AwayTeam ?? "";
            _model.HomeTeamShort = _model.HomeTeamShort ?? "";
            _model.AwayTeamShort = _model.AwayTeamShort ?? "";
            BindingContext = _model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _teams = App.DataManager.GetTeams(t => true);
            CompetitionAutoComplete.DataSource = _teams.Select(t => t.CompetitionName).Distinct().ToList();
            HomeTeamAutoComplete.DataSource = _teams.Select(t => t.Name).Distinct().ToList();
            AwayTeamAutoComplete.DataSource = _teams.Select(t => t.Name).Distinct().ToList();
			HomeTeamShortAutoComplete.DataSource = _teams.Select(t => t.ShortName).Distinct().ToList();
			AwayTeamShortAutoComplete.DataSource = _teams.Select(t => t.ShortName).Distinct().ToList();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private bool Validated()
        {
            // TODO: Validate data.
            return false;
        }

        #region IDisposable Support
        private bool disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.
                _model = null;
                disposedValue = true;
            }
        }

        ~NewMatch() 
        {
           // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
           Dispose(false);
        }

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
