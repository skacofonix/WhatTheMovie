using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Crawler.Domain;
using WTM.Crawler.Services;

namespace WTM.Crawler.Test.Services
{
    [TestFixture]
    public class ShotArchiveServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private IImageDownloader imageDownloader;
        private IImageRepository imageRepository;
        private ShotArchiveService shotArchiveService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            imageDownloader = new ImageDownloader(webClient);
            imageRepository = new ImageRepository();
            shotArchiveService = new ShotArchiveService(webClient, htmlParser, imageDownloader, imageRepository);
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