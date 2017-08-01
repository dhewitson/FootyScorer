using System;
using Xamarin.Forms;

namespace FootyScorer.UI
{
    public class FootyScorerContentPageBase : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SubscribeToMessages();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            UnsubscribeToMessages();
        }

        protected virtual void SubscribeToMessages()
        {
            
        }

        protected virtual void UnsubscribeToMessages()
        {
            
        }
    }
}
