using System.Collections.Generic;
using System.Linq;
using Moq;
using NFluent;
using NUnit.Framework;
using WTM.Crawler.Services;
using WTM.RestApi.Models;
using WTM.RestApi.Services;

namespace WTM.RestApi.Tests.Services
{
    [TestFixture]
    public class ShotOverviewServiceTest
    {
        [Test]
        public void ShouldFindByTag()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.IShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<IShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<IShotArchiveService>();
            var shotNewSubmissionsService = new Mock<IShotNewSubmissionsService>();
            var userService = new Mock<WTM.Crawler.Services.IUserService>();
            var dateTimeServie = new Mock<IDateTimeService>();
            var imageRepository = new Mock<IImageRepository>();
            var shotOverviewService = new ShotSummaryService(shotOverviewCrawler.Object,
                shotFeatureFilmsCrawler.Object,
                shotArchiveCrawler.Object,
                shotNewSubmissionsService.Object,
                userService.Object,
                imageRepository.Object,
                dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.Search(new ShotSearchRequest {Tag = "un"});

            Check.That(shotOverviewResponses.Items.Any()).IsTrue();
        }

        [Test]
        public void ShouldGetArchives()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.IShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<IShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<IShotArchiveService>();
            var shotNewSubmissionsService = new Mock<IShotNewSubmissionsService>();
            var userService = new Mock<WTM.Crawler.Services.IUserService>();
            var imageRepository = new Mock<IImageRepository>();
            var dateTimeServie = new Mock<IDateTimeService>();
            var shotOverviewService = new WTM.RestApi.Services.ShotSummaryService(shotOverviewCrawler.Object,
                shotFeatureFilmsCrawler.Object,
                shotArchiveCrawler.Object,
                shotNewSubmissionsService.Object,
                userService.Object,
                imageRepository.Object,
                dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.GetArchives(new ShotArchivesRequest());

            Check.That(shotOverviewResponses.Items.Any()).IsTrue();
        }

        [Test]
        public void ShouldGetFeatureFilms()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.IShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<IShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<IShotArchiveService>();
            var shotNewSubmissionsService = new Mock<IShotNewSubmissionsService>();
            var userService = new Mock<WTM.Crawler.Services.IUserService>();
            var imageRepository = new Mock<IImageRepository>();
            var dateTimeServie = new Mock<IDateTimeService>();
            var shotOverviewService = new WTM.RestApi.Services.ShotSummaryService(shotOverviewCrawler.Object,
                shotFeatureFilmsCrawler.Object,
                shotArchiveCrawler.Object, 
                shotNewSubmissionsService.Object, 
                userService.Object,
                imageRepository.Object,
                dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.GetFeatureFilms(new ShotFeatureFilmsRequest());

            Check.That(shotOverviewResponses.Items.Any()).IsTrue();
        }

        [Test]
        public void ShouldGetNewSubmissions()
        {
            var shotOverviewCrawler = new Mock<WTM.Crawler.Services.IShotOverviewService>();
            var shotFeatureFilmsCrawler = new Mock<IShotFeatureFilmsService>();
            var shotArchiveCrawler = new Mock<IShotArchiveService>();
            var shotNewSubmissionsService = new Mock<IShotNewSubmissionsService>();
            var userService = new Mock<WTM.Crawler.Services.IUserService>();
            var imageRepository = new Mock<IImageRepository>();
            var dateTimeServie = new Mock<IDateTimeService>();
            var shotOverviewService = new ShotSummaryService(shotOverviewCrawler.Object, 
                shotFeatureFilmsCrawler.Object,
                shotArchiveCrawler.Object,
                shotNewSubmissionsService.Object,
                userService.Object,
                imageRepository.Object,
                dateTimeServie.Object);

            var shotOverviewResponses = shotOverviewService.GetNewSubmissions(new ShotNewSubmissionsRequest());

            Check.That(shotOverviewResponses.Items.Any()).IsTrue();
        }
    }
}
