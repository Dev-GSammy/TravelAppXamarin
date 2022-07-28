using System;
using Plugin.Permissions;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;

namespace TravelAppXamarin.Droid
{
    [Activity(Label = "TravelAppXamarin", Icon = "@mipmap/app_icon_adaptive_fore", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.FormsMaps.Init(this, savedInstanceState);
            //Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState //I don't know why this is not identified.

            // The next three lines below show the naming of the db, the path creation and the combination of both. Then the passage of parameter into the 
            //constructor of the app class.
            string DBname = "TravelApp.sqlite";
            string PathFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string DbFullPath = Path.Combine(PathFolder, DBname);
            LoadApplication(new App(DbFullPath));
        }
        /*
         * To be honest, I know nothing of what this code does as of now. After downloading the plugins for the geolocator and permissions. 
         * The method below has to be created and overriden. Funnily, I found it was automatically created. The namespaces have to be used and...
         * The permissionsimplementation method will be called. 
         */
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);   
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
        }
    }
}