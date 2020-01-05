
namespace isobar_code_test.Models
{
    public class Coords
    {
        public Coords(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }
    }
}