using Xamarin.Forms;
using SQLite.Net;

namespace FootyScorer
{
    public class App : Application
    {
        public App(SQLiteConnection connection)
        {
            MainPage = new FootyScorerPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
