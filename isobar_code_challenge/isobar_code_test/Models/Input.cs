﻿
namespace isobar_code_test.Models
{
    public class Input
    {
        public string Address { get;}
        public int NoOfResults { get;}
        public Input(string address, int noOfResults)
        {
            Address = address;
            NoOfResults = noOfResults;
        }
    }
}