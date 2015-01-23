using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Domain;
using WTM.WebsiteClient.Services;

namespace WTM.WebsiteClient.Test.Services
{
    [TestFixture]
    public class ShotFeatureFilmsServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private ShotFeatureFilmsService shotFeatureFilmService;
        private IServerDateTime serverDateTime;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            shotFeatureFilmService = new ShotFeatureFilmsService(webClient, htmlParser);
            serverDateTime = new ServerDateTime();
        }

        [Test]
        public void WhenParseFeatureFilmsOfTheDayThenReturnOverviewShotCollection()
        {
            var today = serverDateTime.GetDateTime();
            var overviewShotCollection = shotFeatureFilmService.GetTodayShots();
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.OverviewShotType).Equals(OverviewShotType.FeatureFilms);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
            Check.That(overviewShotCollection.Date.Value.Date).Equals(today.Date);
        }

        [Test]
        public void WhenParseFeatureFilmsOfYesterdayThenReturnOverviewShotCollection()
        {
            var yesterday = serverDateTime.GetDateTime().AddDays(-1);
            var overviewShotCollection = shotFeatureFilmService.GetShotyByDate(yesterday);
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.OverviewShotType).Equals(OverviewShotType.FeatureFilms);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
            Check.That(overviewShotCollection.Date.Value.Date).Equals(yesterday.Date);
        }
    }
}