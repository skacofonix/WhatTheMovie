using NFluent;
using NUnit.Framework;
using System.Linq;
using WTM.Core.Application;
using WTM.Core.Domain.WebsiteEntities;
using WTM.Core.Services;

namespace WTM.Core.Test.Services
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

            var authentifier = new Authentifier(webClient, htmlParser);
            if (authentifier.Login("captainOblivious", "captainOblivious"))
                webClient.SetCookie(authentifier.CookieSession);
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
            Check.That(overviewShotCollection.Date.Value.Date).Equals(today.Value.Date);
        }

        [Test]
        public void WhenParseFeatureFilmsOfYesterdayThenReturnOverviewShotCollection()
        {
            var yesterday = serverDateTime.GetDateTime().Value.AddDays(-1);
            var overviewShotCollection = shotFeatureFilmService.GetShotyByDate(yesterday);
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.OverviewShotType).Equals(OverviewShotType.FeatureFilms);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
            Check.That(overviewShotCollection.Date.Value.Date).Equals(yesterday.Date);
        }
    }
}
