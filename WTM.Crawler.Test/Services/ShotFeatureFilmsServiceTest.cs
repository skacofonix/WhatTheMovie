using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Crawler.Domain;
using WTM.Crawler.Services;

namespace WTM.Crawler.Test.Services
{
    [TestFixture]
    public class ShotFeatureFilmsServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private IImageDownloader imageDownloader;
        private IImageRepository imageRepository;
        private ShotFeatureFilmsService shotFeatureFilmService;
        private IServerDateTimeService serverDateTime;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            imageDownloader= new ImageDownloader(webClient);
            shotFeatureFilmService = new ShotFeatureFilmsService(webClient, htmlParser, imageDownloader, imageRepository);
            serverDateTime = new ServerDateTimeService(webClient);
        }

        [Test]
        public void WhenParseFeatureFilmsOfTheDayThenReturnOverviewShotCollection()
        {
            var today = serverDateTime.GetDateTime();
            var overviewShotCollection = shotFeatureFilmService.GetShotSummaryToday();
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.ShotType).Equals(ShotType.FeatureFilms);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Date.Value.Date).Equals(today.Value.Date);
        }

        [Test]
        public void WhenParseFeatureFilmsOfYesterdayThenReturnOverviewShotCollection()
        {
            var yesterday = serverDateTime.GetDateTime().Value.AddDays(-1);
            var overviewShotCollection = shotFeatureFilmService.GetShotSummaryByDate(yesterday);
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.ShotType).Equals(ShotType.FeatureFilms);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
            Check.That(overviewShotCollection.Date.Value.Date).Equals(yesterday.Date);
        }
    }
}