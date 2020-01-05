using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;
using isobar_code_test.Models;

namespace isobar_code_test.Helper
{
    public static class HelperExtension
    {
        public static string[] ReadFile(string path)
        {
            string serverpath = HttpContext.Current.Server.MapPath(path);
            string[] lines = File.ReadAllLines(serverpath, Encoding.UTF8);
            return lines;
        }
        public static Coords GetLatLngFromAddress(string address)
        {
            using (var client = new WebClient())
            {
                string uri = "https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + Constants.APIKey;
                string geocodeInfo = client.DownloadString(uri);
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                GoogleGeoCodeResp latlongdata = oJS.Deserialize<GoogleGeoCodeResp>(geocodeInfo);
                return new Coords(Convert.ToDouble(latlongdata.results[0].geometry.location.lat), Convert.ToDouble(latlongdata.results[0].geometry.location.lng));
            }
        }
        
        public static double GetDistanceBetweenTwoPoints(Coords startLocation,Coords destinationLocation)
        {
            var startCoord = new GeoCoordinate(startLocation.Latitude, startLocation.Longitude);
            var destinationCoord = new GeoCoordinate(destinationLocation.Latitude, destinationLocation.Longitude);
            return Math.Round(startCoord.GetDistanceTo(destinationCoord)/1000,2);
        }
    }
}