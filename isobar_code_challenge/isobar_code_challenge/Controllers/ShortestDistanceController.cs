using isobar_code_challenge.Helper;
using isobar_code_challenge.Logger;
using isobar_code_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace isobar_code_challenge.Controllers
{
    public class ShortestDistanceController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetDistancesbetweenAddress([FromBody]Input input)
        {
            string path = "Data\\address list australia.txt";
            Coords locationCoords = HelperExtension.GetLatLngFromAddress(input.Address);
            string[] lines = HelperExtension.ReadFile(path);
            List<Distance> distances = new List<Distance>();
            if (lines != null)
            {
                foreach (var line in lines)
                {
                    Coords destinationCoords = HelperExtension.GetLatLngFromAddress(line);
                    double distance = HelperExtension.GetDistanceBetweenTwoPoints(locationCoords, destinationCoords);
                    var dist = new Distance(input.Address, line, distance);
                    distances.Add(dist);
                }
            }
            if (distances.Count > 0)
            {
                return Ok(distances.OrderBy(x => x.Distanceinkm).Take(input.NoOfResults).ToList());
            }
            else
            {
                Log.Info("No results found");
                return NotFound();
            }
        }
    }
}
