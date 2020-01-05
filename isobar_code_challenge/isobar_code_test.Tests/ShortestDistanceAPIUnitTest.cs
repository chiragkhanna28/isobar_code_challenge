using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using isobar_code_test.Controllers;
using isobar_code_test.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace isobar_code_test.Tests
{
    [TestClass]
    public class ShortestDistanceAPIUnitTest
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
