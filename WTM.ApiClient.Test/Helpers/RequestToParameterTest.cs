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
            var foo = new ShotSearchRequest
            {
                Start = 10,
                Limit = 50,
                Tag = "redhead",
                Token = "ab482fa08a178daa"
            };
            Assert.AreEqual("?limit=50&start=10&tag=redhead&token=ab482fa08a178daa", foo.ToRequestString());
        }
    }
}
