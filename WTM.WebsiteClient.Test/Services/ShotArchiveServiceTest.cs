using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Domain;
using WTM.WebsiteClient.Services;

namespace WTM.WebsiteClient.Test.Services
{
    [TestFixture]
    public class ShotArchiveServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private ShotArchiveService shotArchiveService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            shotArchiveService = new ShotArchiveService(webClient, htmlParser);
        }

        [Test]
        public void WhenParseTheArchiveThenReturnOverviewShotCollection()
        {
            var overviewShotCollection = shotArchiveService.GetArchiveOneMonthOld();
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.ShotType).Equals(ShotType.Archive);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
        }
    }
}