using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAppXamarin.Helpers
{
    public class Constants
    { 
        //to define the values gotten from the foursquare venues api for userless authentication.
       
        public const string VENUE_SEARCH = "https://nominatim.openstreetmap.org/?addressdetails=1&q={0}&format=json&limit=1";
        //public const string CLIENT_ID = "XGFMTTYWYXXKAHYHUYPBBAR3TN2H4DXXGBAKDCREP3D0SWGL";
        //public const string CLIENT_SECRET = "44SMGVN4CGAIKITXOEBNPS33JRWTH0ZABWZIB4HGYJQUD55P";
        public static string query = "Popular Restuarants";
        //public static string Date = DateTime.Now.ToString("yyyyMMdd");
    }
}