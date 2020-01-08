
namespace isobar_code_challenge.Models
{
    public class GoogleGeoCodeResp
    {
        public string status { get; set; }
        public Results[] results { get; set; }
    }

    public class Results
    {
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string[] types { get; set; }
        public Address_component[] address_components { get; set; }
    }

    public class Geometry
    {
        public string location_type { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Address_component
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
}