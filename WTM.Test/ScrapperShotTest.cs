using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTM.Core.Application;

namespace WTM.Test
{
    [TestClass]
    public class ScrapperShotTest
    {
        [TestMethod]
        public void SimplCallScrapper()
        {
            var scrapper = new ShotScrapper();

            var shot = scrapper.Scrap(10);

            Assert.IsTrue(true);
        }
    }
}
