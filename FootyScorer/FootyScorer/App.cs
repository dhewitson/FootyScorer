using Xamarin.Forms;
using SQLite.Net;
using FootyScorer.Data;
using FootyScorer.UI;
using FootyScorer.Constants;
using FootyScorer.ViewModel;
using System;

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

   //         var m = DataManager.CreateNewMatch();

   //         m.Date = DateTime.Now.AddDays(-8);
   //         m.HomeTeam = "Lyndhurst Orange";
   //         m.AwayTeam = "Pakenham Blue";
   //         m.CompetitionName = "SEJ U8 Blue";
   //         m.AwayTeamShort = "PAK";
   //         m.HomeTeamShort = "LFC";
   //         m.Round = "Round 7";
   //         m.Venue = "Marriott Waters Oval 1";
   //         m.HomeScore = new ScoreViewModel
   //         {
   //             Id = Guid.NewGuid(),
   //             QuarterOneGoals = 1,
   //             QuarterOnePoints = 1,
   //             QuarterTwoGoals = 4,
   //             QuarterTwoPoints = 2,
   //             QuarterThreeGoals = 3,
   //             QuarterThreePoints = 7,
   //             QuarterFourGoals = 2,
   //             QuarterFourPoints = 0
   //         };
			//m.AwayScore = new ScoreViewModel
			//{
   //             Id = Guid.NewGuid(),
			//	QuarterOneGoals = 0,
			//	QuarterOnePoints = 1,
			//	QuarterTwoGoals = 0,
			//	QuarterTwoPoints = 2,
			//	QuarterThreeGoals = 4,
			//	QuarterThreePoints = 2,
			//	QuarterFourGoals = 3,
			//	QuarterFourPoints = 0
			//};

   //         DataManager.SaveMatch(m);

			//m = DataManager.CreateNewMatch();

			//m.Date = DateTime.Now.AddDays(-15);
			//m.HomeTeam = "Lyndhurst Orange";
			//m.AwayTeam = "Officer Black";
			//m.CompetitionName = "SEJ U8 Blue";
			//m.AwayTeamShort = "OFF";
			//m.HomeTeamShort = "LFC";
			//m.Round = "Round 6";
			//m.Venue = "Marriott Waters Oval 1";
			//m.HomeScore = new ScoreViewModel
			//{
   //             Id = Guid.NewGuid(),
			//	QuarterOneGoals = 1,
			//	QuarterOnePoints = 1,
			//	QuarterTwoGoals = 4,
			//	QuarterTwoPoints = 2,
			//	QuarterThreeGoals = 3,
			//	QuarterThreePoints = 7,
			//	QuarterFourGoals = 2,
			//	QuarterFourPoints = 0
			//};
			//m.AwayScore = new ScoreViewModel
			//{
   //             Id = Guid.NewGuid(),
			//	QuarterOneGoals = 1,
			//	QuarterOnePoints = 1,
			//	QuarterTwoGoals = 4,
			//	QuarterTwoPoints = 2,
			//	QuarterThreeGoals = 3,
			//	QuarterThreePoints = 7,
			//	QuarterFourGoals = 2,
			//	QuarterFourPoints = 0
			//};

			//DataManager.SaveMatch(m);

			//m = DataManager.CreateNewMatch();

			//m.Date = DateTime.Now.AddDays(-22);
			//m.HomeTeam = "Berwick Springs Green";
			//m.AwayTeam = "Lyndhurst Orange";
			//m.CompetitionName = "SEJ U8 Blue";
			//m.AwayTeamShort = "LFC";
			//m.HomeTeamShort = "BER";
			//m.Round = "Round 5";
			//m.Venue = "Berwick Springs Park 2";
			//m.HomeScore = new ScoreViewModel
			//{
   //             Id = Guid.NewGuid(),
			//	QuarterOneGoals = 1,
			//	QuarterOnePoints = 1,
			//	QuarterTwoGoals = 1,
			//	QuarterTwoPoints = 0,
			//	QuarterThreeGoals = 5,
			//	QuarterThreePoints = 0,
			//	QuarterFourGoals = 4,
			//	QuarterFourPoints = 4
			//};
			//m.AwayScore = new ScoreViewModel
			//{
   //             Id = Guid.NewGuid(),
			//	QuarterOneGoals = 6,
			//	QuarterOnePoints = 3,
			//	QuarterTwoGoals = 1,
			//	QuarterTwoPoints = 2,
			//	QuarterThreeGoals = 2,
			//	QuarterThreePoints = 3,
			//	QuarterFourGoals = 4,
			//	QuarterFourPoints = 6
			//};

			//DataManager.SaveMatch(m);

			//m = DataManager.CreateNewMatch();

			//m.Date = DateTime.Now.AddDays(-29);
			//m.HomeTeam = "Pakenham Blue";
			//m.AwayTeam = "Lyndhurst Orange";
			//m.CompetitionName = "SEJ U8 Blue";
			//m.AwayTeamShort = "LFC";
			//m.HomeTeamShort = "PAK";
			//m.Round = "Round 4";
			//m.Venue = "Major Recreation Reserve 3";
			//m.HomeScore = new ScoreViewModel
			//{
   //             Id = Guid.NewGuid(),
			//	QuarterOneGoals = 0,
			//	QuarterOnePoints = 1,
			//	QuarterTwoGoals = 5,
			//	QuarterTwoPoints = 2,
			//	QuarterThreeGoals = 5,
			//	QuarterThreePoints = 2,
			//	QuarterFourGoals = 2,
			//	QuarterFourPoints = 4
			//};
			//m.AwayScore = new ScoreViewModel
			//{
   //             Id = Guid.NewGuid(),
			//	QuarterOneGoals = 6,
			//	QuarterOnePoints = 3,
			//	QuarterTwoGoals = 0,
			//	QuarterTwoPoints = 2,
			//	QuarterThreeGoals = 2,
			//	QuarterThreePoints = 3,
			//	QuarterFourGoals = 2,
			//	QuarterFourPoints = 6
			//};

			//DataManager.SaveMatch(m);

            MainPage =  new NavigationPage(new LandingPage()) { BarBackgroundColor = ThemeSettings.ToolbarColor, BarTextColor = ThemeSettings.ToolbarButtonColor };
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
            if (Device.RuntimePlatform == Device.iOS)
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
            }

            if (Device.RuntimePlatform == Device.Android)
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
            }

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
