using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace isobar_code_test.Models
{
    public class Distance
    {
        public string StartLocation { get; set; }
        public string DestinationLocation { get; set; }
        public double Distanceinkm { get; set; }
        public Distance(string startLocation, string destinationLocation, double distanceinKM)
        {
            StartLocation = startLocation;
            DestinationLocation = destinationLocation;
            Distanceinkm = distanceinKM;
        }
    }
}