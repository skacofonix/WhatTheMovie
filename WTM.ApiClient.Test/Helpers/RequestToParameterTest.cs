using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTM.ApiClient.Models;
using WTM.ApiClient.Helpers;

namespace WTM.ApiClient.Test
{
    [TestClass]
    public class RequestToParameterTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var shotSearchRequest = new ShotSearchRequest
            {
                Start = 10,
                Limit = 50,
                Tag = "redhead",
                Token = "ab482fa08a178daa"
            };
            Assert.AreEqual("?limit=50&start=10&tag=redhead&token=ab482fa08a178daa", shotSearchRequest.ToRequestString());

            var shotRequest = new ShotRequest
            {
                Id = 10,
                Token = "ab482fa08a178daa"
            };
            Assert.AreEqual("?token=ab482fa08a178daa", shotRequest.ToRequestString());

            var shotsRequest = new ShotsRequest
            {
                Date = DateTime.Parse("2015-08-25"),
                Start = 10,
                Limit = 50,
                Token = "ab482fa08a178daa"
            };
            Assert.AreEqual("?date=2015-08-25&limit=50&start=10&token=ab482fa08a178daa", shotsRequest.ToRequestString());
        }
    }
}
