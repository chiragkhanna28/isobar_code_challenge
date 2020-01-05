using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace isobar_code_test.Models
{
    public class Input
    {
        public string Address { get; set; }
        public int NoOfResults { get; set; }
        public Input(string address, int noOfResults)
        {
            Address = address;
            NoOfResults = noOfResults;
        }
    }
}