using isobar_code_challenge.Logger;
using isobar_code_challenge.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace isobar_code_challenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [OutputCache(Duration = 60, VaryByParam = "address")]
        public ActionResult Index(string address)
        {
            int noofresults = Constants.noOfResults;
            var distanceList = new DistanceList();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58578/api/");
                var input = new Input(address, noofresults);
                var responseTask = client.PostAsJsonAsync<Input>("shortestDistance", input);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Distance>>();
                    readTask.Wait();
                    var distances = readTask.Result;
                    distanceList.Distances = distances;
                    distanceList.Success = true;
                    Log.Info("Status from Web api is OK");
                }
                else
                {
                    distanceList.Success = false;
                    Log.Info("Status from Web api is Not found");
                }
            }
            return View(distanceList);
        }
    }
}