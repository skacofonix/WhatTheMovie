using NFluent;
using NUnit.Framework;
using System;
using System.Linq;
using WTM.Api.Core.Services;

namespace WTM.Api.Core.Test.Services
{
    [TestFixture]
    public class FeatureFilmsServiceTest
    {
        //private FeatureFilmsService featureFilmService;

        [SetUp]
        public void BeforTest()
        {
            //var context = new Context();
            //featureFilmService = new FeatureFilmsService(context);
        }

        [Test]
        public void WhenGetShotSummaryTHenReturnEnumerationOfShotSummary()
        {
            Assert.Inconclusive();
            //var shotSummaryList = featureFilmService.GetShotSummary(new DateTime(2008, 8, 31));
            //Check.That(shotSummaryList.Count()).IsGreaterThan(0);
        }
    }
}