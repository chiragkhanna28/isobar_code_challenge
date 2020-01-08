
namespace isobar_code_challenge.Models
{
    public class Distance
    {
        public string StartLocation { get; }
        public string DestinationLocation { get; }
        public double Distanceinkm { get; }
        public Distance(string startLocation, string destinationLocation, double distanceinKM)
        {
            StartLocation = startLocation;
            DestinationLocation = destinationLocation;
            Distanceinkm = distanceinKM;
        }
    }
}