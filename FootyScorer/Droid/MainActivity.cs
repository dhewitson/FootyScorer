using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.IO;

namespace FootyScorer.Droid
{
    [Activity(Label = "FootyScorer.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());
                  
            global::Xamarin.Forms.Forms.Init(this, bundle);

            FormsPlugin.Iconize.Droid.IconControls.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);

            AppDomain.CurrentDomain.UnhandledException += (sender, e) => {
                
            };

            TaskScheduler.UnobservedTaskException += (sender, e) => {
                
            };

            AndroidEnvironment.UnhandledExceptionRaiser += (sender, e) => {
                
            };

            const string dbName = "gamedb.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(documentsPath, dbName);

            if (!File.Exists(dbPath))
            {
                using (var br = new BinaryReader(Assets.Open(dbName)))
                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        var buffer = new byte[2048];
                        int len;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                            bw.Write(buffer, 0, len);
                    }
                }
            }

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            try
            {
                LoadApplication(new App(new SQLite.Net.SQLiteConnection(platform, dbPath, false)));
            }
            catch (Exception ex)
            {}
        }

        protected override async void OnResume()
        {
            base.OnResume();
            await Task.Delay(300);
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        }
    }
}
