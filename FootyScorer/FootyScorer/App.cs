using Xamarin.Forms;
using SQLite.Net;
using FootyScorer.Data;

namespace FootyScorer
{
    public class App : Application
    {
        /// <summary>
        /// Gets the data manager.
        /// </summary>
        /// <value>The data manager.</value>
        public static DataManager DataManager { get; private set; }

        public App(SQLiteConnection connection)
        {
            ApplyTheming();
            DataManager = new DataManager(connection);
            MainPage = new UI.LandingPage();
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

        private void ApplyTheming()
        {
			var buttonStyle = new Style(typeof(Button))
			{
				Setters =
				{
					new Setter
					{
						Property = Button.TextColorProperty,
						Value = Color.White
					},
					new Setter
					{
						Property = VisualElement.BackgroundColorProperty,
						Value = Color.Black
					}
				}
			};

			Device.OnPlatform(
			() =>
			{
				buttonStyle.Setters.Add(new Setter
				{
					Property = Button.FontSizeProperty,
					Value = 16
				});

				buttonStyle.Setters.Add(new Setter
				{
					Property = VisualElement.HeightRequestProperty,
					Value = 15
				});
			},
			() =>
			{
				buttonStyle.Setters.Add(new Setter
				{
					Property = Button.FontSizeProperty,
					Value = 15
				});
				buttonStyle.Setters.Add(new Setter
				{
					Property = VisualElement.HeightRequestProperty,
					Value = 40
				});
			});

			var labelStyle = new Style(typeof(Label))
			{
				Setters =
				{
					new Setter
					{
						Property = Label.FontSizeProperty,
						Value = 14
					},
					new Setter
					{
						Property = Label.TextColorProperty,
						Value = Color.Black
					}
				}
			};

			Current.Resources = new ResourceDictionary { buttonStyle, labelStyle };
        }
    }
}
