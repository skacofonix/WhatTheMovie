using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Crawler.Services;
using WTM.Domain;

namespace WTM.Crawler.Test.Services
{
    [TestFixture]
    public class ShotNewSubmissionsServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private ShotNewSubmissionsService shotNewSubmissionsService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            shotNewSubmissionsService = new ShotNewSubmissionsService(webClient, htmlParser);

            // New Submission need to be connected to works !

            var authenticateService = new AuthenticateService(webClient, htmlParser);
            authenticateService.Login("captainOblivious", "captainOblivious");
        }

        [Test]
        public void WhenParseNewSubmissionsThenReturnOverviewShotCollection()
        {
            var overviewShotCollection = shotNewSubmissionsService.GetShots();
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.ShotType).IsNotNull();
            Check.That(overviewShotCollection.ShotType).Equals(ShotType.NewSubmissions);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
        }
    }
}
