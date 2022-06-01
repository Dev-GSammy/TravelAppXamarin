using System;
using System.Collections.Generic;
using System.Text;
using TravelAppXamarin.Helpers;

namespace TravelAppXamarin.Model
{
    public class Address
    {
        public string amenity { get; set; }
        public string road { get; set; }
        public string town { get; set; }
        public string state { get; set; }
        //public string ISO3166-2-lvl4 { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Country_code { get; set; }
    }

        public class Universities
{
        public int place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public int osm_id { get; set; }
        public IList<string> boundingbox { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string display_name { get; set; }
        public string classes { get; set; }
        public string type { get; set; }
        public double importance { get; set; }
        public string icon { get; set; }
        public List<Address> address { get; set; }

    }
    public class VenueRoot
    {
        
        public static string GenerateURL(double latitude, double longitude)
        {
            //return string.Format(Constants.VENUE_SEARCH, latitude, longitude, Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
            return string.Format(Constants.VENUE_SEARCH, Constants.query);
        }
        public static string GenerateURL()
        {
            return string.Format(Constants.VENUE_SEARCH, Constants.query);
        }
    }
}
