using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTM.Core.Application;
using System.Diagnostics;

namespace WTM.Test
{
    [TestClass]
    public class ScrapperShotTest
    {
        [TestMethod]
        public void SimplCallScrapper()
        {
            var scrapper = new ShotScrapper();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var shot = scrapper.Scrap(10);
            sw.Stop();

            Assert.IsTrue(shot != null);
        }
    }
}
