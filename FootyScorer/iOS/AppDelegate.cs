using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;

namespace FootyScorer.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

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

            return base.FinishedLaunching(app, options);
        }
    }
}
