using System.Collections.Generic;

namespace isobar_code_challenge.Models
{
    public class DistanceList
    {
        public IEnumerable<Distance> Distances { get; set; }
        public bool Success { get; set; }
    }
}