using isobar_code_challenge.Controllers;
using isobar_code_challenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace isobar_code_challenge.Tests.Controllers
{
    [TestClass]
    public class ShortestDistanceControllerTest
    {
        [TestMethod]
        public void ShortestDistance()
        {
            string address = "Preet Vihar,Delhi";
            int count = 5;
            var input = new Input(address, count);
            var shortestDistanceController = new ShortestDistanceController();
            var response = shortestDistanceController.GetDistancesbetweenAddress(input);
            var responseResult = response as OkNegotiatedContentResult<List<Distance>>;
            Assert.IsNotNull(responseResult);
            Assert.AreEqual(5, responseResult.Content.Count);
        }
    }
}
