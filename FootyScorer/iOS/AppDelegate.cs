using System.IO;
using Foundation;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;

namespace FootyScorer.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Xamarin.Forms.Forms.Init();
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());
            FormsPlugin.Iconize.iOS.IconControls.Init();
                  
            UINavigationBar.Appearance.TintColor = UIColor.Black;

            var platform = new SQLitePlatformIOS();

            const string dbName = "gamedb.db3";
            var path = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0].Path;
            var dbPath = Path.Combine(path, dbName);

            if (!File.Exists(dbPath))
            {
                var appDir = NSBundle.MainBundle.ResourcePath;
                var seedFile = Path.Combine(appDir, dbName);
                if (File.Exists(seedFile))
                    File.Copy(seedFile, dbPath);
            }

            LoadApplication(new App(new SQLite.Net.SQLiteConnection(platform, dbPath, false)));

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
