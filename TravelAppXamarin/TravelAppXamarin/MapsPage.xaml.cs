using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Permissions;
using Plugin.Geolocator;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator.Abstractions;

namespace TravelAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        bool hasLocationPermission = false;
        public MapsPage()
        {
            InitializeComponent();

            GetPermissions(); 
        }

        private async void GetPermissions()
        {
            //this particular region will have to be added immediately after the expectation of the plugin writer in the mainActivity and info.plist.
            //From the way eduardo explained it, it seems quite understandable. But I must say that as of now, I DON'T GET IT. 
            //I can try to explain it to my self though.
            #region
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Location", "Please give access to your location", "Okay");
                    }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                    {
                        status = results[Permission.LocationWhenInUse];
                    }
                }
                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationsMap.IsShowingUser = true;
                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location", "Please give access to your location", "Okay");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Okay");
            }
            #endregion

        }

        //The code below is used to get the exact location of the user automatically even he changes location. The plugin used is the Xam.geolocator
        //This particular code gets the new location. Next is to move the map to the location result address.   
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                //To prevent the app from always listening thereby draining battery life, the following code is implemented
                await locator.StartListeningAsync(TimeSpan.Zero, 100); //zero timespan tells it not to move by time but by distance (100meters)
            }

                GetLocation();
        }
        /*
         * This method unsubscribes from the ability to listen to distance which can waste battery life.
         */
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }
        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();
                MoveMap(position);
            }
        }
        private void MoveMap(Position position)
        {
            //The line below can be written in full if wanted. Function is to move the map to the postion already gotten.
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            locationsMap.MoveToRegion(span);
        }
    }
}