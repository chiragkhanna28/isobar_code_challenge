using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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