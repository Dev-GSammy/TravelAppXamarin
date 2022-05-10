using System;
using System.Collections.Generic;
using System.Text;
using TravelAppXamarin.Helpers;

namespace TravelAppXamarin.Model
{
    public class Venues
    {
        public static string GenerateURL(double latitude, double longitude)
        {
            
            return string.Format(Constants.VENUE_SEARCH, latitude, longitude, Constants.CLIENT_ID, Constants.CLIENT_SECRET, Constants.Date);    
        }
    }
}
