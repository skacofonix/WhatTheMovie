using NFluent;
using NUnit.Framework;
using System.Linq;
using WTM.Core.Application;
using WTM.Core.Domain.WebsiteEntities;
using WTM.Core.Services;

namespace WTM.Core.Test.Services
{
    [TestFixture]
    public class ShotArchiveServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private ShotArchiveService shotArchiveService;
        private IServerDateTime serverDateTime;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            shotArchiveService = new ShotArchiveService(webClient, htmlParser);
            serverDateTime = new ServerDateTime();
        }

        [Test]
        public void WhenParseTheARcgiveThenReturnOverviewShotCollection()
        {
            var overviewShotCollection = shotArchiveService.GetArhciveOneMonthOld();
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.OverviewShotType).Equals(OverviewShotType.FeatureFilms);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
        }
    }
}