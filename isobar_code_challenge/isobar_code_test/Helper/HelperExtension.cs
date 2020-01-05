using System;
using System.Device.Location;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using isobar_code_test.Models;

namespace isobar_code_test.Helper
{
    public static class HelperExtension
    {
        public static string[] ReadFile(string path)
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path); 
            string[] lines = null;
            if (File.Exists(filepath))
            {
                lines = File.ReadAllLines(filepath, Encoding.UTF8);
            }
            return lines;
        }
        public static Coords GetLatLngFromAddress(string address)
        {
            try
            {
                using (var client = new WebClient())
                {
                    string mapurl = "https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + Constants.APIKey;
                    string geocodeInfo = client.DownloadString(mapurl);
                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    GoogleGeoCodeResp latlongdata = javaScriptSerializer.Deserialize<GoogleGeoCodeResp>(geocodeInfo);
                    return new Coords(Convert.ToDouble(latlongdata.results[0].geometry.location.lat), Convert.ToDouble(latlongdata.results[0].geometry.location.lng));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetLatLngFromAddress Method " + ex.Message);
            }
        }
        
        public static double GetDistanceBetweenTwoPoints(Coords startLocation,Coords destinationLocation)
        {
            try
            {
                var startCoord = new GeoCoordinate(startLocation.Latitude, startLocation.Longitude);
                var destinationCoord = new GeoCoordinate(destinationLocation.Latitude, destinationLocation.Longitude);
                return Math.Round(startCoord.GetDistanceTo(destinationCoord) / 1000, 2);
            }catch(Exception ex)
            {
                throw new Exception("Error in GetDistanceBetweenTwoPoints Method " + ex.Message);
            }
        }
    }
}