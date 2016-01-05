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
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.IShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<IShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<IShotArchiveService>();
            var shotNewSubmissionsService = new Mock<IShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();
            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.SearchByDate(null, null, null);

            Check.That(shotOverviewResponses.Items.Any()).IsTrue();
        }

        [Test]
        public void ShouldFindByTag()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.IShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<IShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<IShotArchiveService>();
            var shotNewSubmissionsService = new Mock<IShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();
            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.SearchByTag(new List<string> {"un"}, null, null);

            Check.That(shotOverviewResponses.Items.Any()).IsTrue();
        }

        [Test]
        public void ShouldGetArchives()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.IShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<IShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<IShotArchiveService>();
            var shotNewSubmissionsService = new Mock<IShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();
            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.GetArchives(null, null, null);

            Check.That(shotOverviewResponses.Items.Any()).IsTrue();
        }

        [Test]
        public void ShouldGetFeatureFilms()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.IShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<IShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<IShotArchiveService>();
            var shotNewSubmissionsService = new Mock<IShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();
            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.GetFeatureFilms(null, null, null);

            Check.That(shotOverviewResponses.Items.Any()).IsTrue();
        }

        [Test]
        public void ShouldGetNewSubmissions()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.IShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<IShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<IShotArchiveService>();
            var shotNewSubmissionsService = new Mock<IShotNewSubmissionsService>();
            var dateTimeServie = new Mock<IDateTimeService>();
            var shotOverviewService = new WTM.RestApi.Services.ShotOverviewService(shotOverviewCrawler.Object, shotFeatureFilmsCrawler.Object, shotArchiveCrawler.Object, shotNewSubmissionsService.Object, dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.GetNewSubmissions(null, null, null);

            Check.That(shotOverviewResponses.Items.Any()).IsTrue();
        }
    }
}
