using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAppXamarin.Helpers
{
    public class Constants
    {
        //to define the values gotten from the foursquare venues api for userless authentication.
        public const string VENUE_SEARCH = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
    }
}
