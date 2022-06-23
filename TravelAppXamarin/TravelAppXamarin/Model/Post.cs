using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAppXamarin.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        public string AddressAmenity { get; set; }
        public string AddressRoad { get; set; }
        public string AddressTown { get; set; }
        public string AddressState { get; set; }
        public double UniversityLongitude { get; set; }
        public double UniversityLatitude { get; set; }
    }
}
