using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using isobar_code_test.Helper;
using isobar_code_test.Models;

namespace isobar_code_test.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpPost]
        public IEnumerable<Distance> GetDistancesbetweenAddress([FromBody]Input input)
        {
            string path = "~/Data/address list australia.txt";
            Coords locationCoords = HelperExtension.GetLatLngFromAddress(input.Address);
            string[] lines = HelperExtension.ReadFile(path);
            List<Distance> distances = new List<Distance>();
            foreach(var line in lines)
            {
                Coords destinationCoords = HelperExtension.GetLatLngFromAddress(line);
                double distance = HelperExtension.GetDistanceBetweenTwoPoints(locationCoords, destinationCoords);
                var dist = new Distance(input.Address, line, distance);
                distances.Add(dist);
            }
            return distances.OrderBy(x => x.Distanceinkm).Take(input.NoOfResults);
        }
    }
}
