using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTM.Core.Application;
using System.Diagnostics;
using System.IO;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Test
{
    [TestClass]
    public class ScrapperShotTest
    {
        [TestMethod]
        public void SimplCallScrapper()
        {
            var scrapper = new ShotScrapper();
            Shot shot = null;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var file = "10.htm";
            using(var fs = File.OpenRead(file))
            {
                shot = scrapper.Scrap(fs);
            }

            sw.Stop();


            Assert.IsTrue(shot != null);
        }
    }
}
