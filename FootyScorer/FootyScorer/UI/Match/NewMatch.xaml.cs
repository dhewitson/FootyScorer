using System;
using FootyScorer.Constants;
using FootyScorer.ViewModel;
using Xamarin.Forms;

namespace FootyScorer.UI.Match
{
    public partial class NewMatch : ContentPage, IDisposable
    {
        private MatchViewModel _model;

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
            BindingContext = _model;
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
