using System.Collections.Generic;
using System.Linq;
using Moq;
using NFluent;
using NUnit.Framework;
using WTM.Crawler.Services;
using WTM.RestApi.Services;

namespace WTM.RestApi.Tests.Services
{
    [TestFixture]
    public class ShotOverviewServiceTest
    {
        [Test]
        public void ShouldFindByDate()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.ShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<ShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<ShotArchiveService>();
            var shotNewSubmissionsService = new Mock<ShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();

            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.FindByDate(null, null, null);

            Check.That(shotOverviewResponses.Any()).IsTrue();
        }

        [Test]
        public void ShouldFindByTag()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.ShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<ShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<ShotArchiveService>();
            var shotNewSubmissionsService = new Mock<ShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();

            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.FindByTag(new List<string> {"un"}, null, null);

            Check.That(shotOverviewResponses.Any()).IsTrue();
        }

        [Test]
        public void ShouldGetArchives()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.ShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<ShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<ShotArchiveService>();
            var shotNewSubmissionsService = new Mock<ShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();

            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.GetArchives(null, null, null);

            Check.That(shotOverviewResponses.Any()).IsTrue();
        }

        [Test]
        public void ShouldGetFeatureFilms()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.ShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<ShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<ShotArchiveService>();
            var shotNewSubmissionsService = new Mock<ShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();

            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.GetFeatureFilms(null, null, null);

            Check.That(shotOverviewResponses.Any()).IsTrue();
        }

        [Test]
        public void ShouldGetNewSubmissions()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.ShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<ShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<ShotArchiveService>();
            var shotNewSubmissionsService = new Mock<ShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();

            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.GetNewSubmissions(null, null, null);

            Check.That(shotOverviewResponses.Any()).IsTrue();
        }
    }
}
