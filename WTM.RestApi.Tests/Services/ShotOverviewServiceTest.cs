using System.Linq;
using Moq;
using NFluent;
using NUnit.Framework;
using WTM.Crawler.Services;
using WTM.RestApi.Services;
using ShotOverviewService = WTM.RestApi.Services.ShotOverviewService;

namespace WTM.RestApi.Tests.Services
{
    [TestFixture]
    public class ShotOverviewServiceTest
    {
        [Test]
        public void ShouldSomething()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.ShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<ShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<ShotArchiveService>();
            var shotNewSubmissionsService = new Mock<ShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();

            var shotOverviewService = new ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.FindByDate(null, null, null);

            Check.That(shotOverviewResponses.Any()).IsTrue();
        }
    }
}
