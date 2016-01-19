using NFluent;
using NUnit.Framework;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.RestApi.Services;
using IShotService = WTM.RestApi.Services.IShotService;
using ShotService = WTM.RestApi.Services.ShotService;
using UserService = WTM.Crawler.Services.UserService;

namespace WTM.RestApi.Tests.Services
{
    [TestFixture]
    public class ImageResourceServiceTest
    {
        private ImageResourceService imageResourceService;

        [SetUp]
        public void Initialize()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            var imageRepository = new ImageRepository();
            var imageDownloader = new ImageDownloader(webClient);
            var dateTimeService = new DateTimeService();
            var shotService = new ShotService(new Crawler.Services.ShotService(webClient, htmlParser));
            var shotSummaryService = new ShotSummaryService(
                new ShotOverviewService(webClient, htmlParser, imageDownloader, imageRepository),
                new ShotFeatureFilmsService(webClient, htmlParser, imageDownloader, imageRepository),
                new ShotArchiveService(webClient, htmlParser, imageDownloader, imageRepository),
                new ShotNewSubmissionsService(webClient, htmlParser, imageDownloader, imageRepository),
                new UserService(webClient, htmlParser),
                imageRepository,
                dateTimeService);
            this.imageResourceService = new ImageResourceService(imageDownloader, imageRepository, shotService, shotSummaryService);
        }

        [Test]
        public void ShouldGetShotThumbnail()
        {
            Check.That(this.imageResourceService.GetThumbnail(10)).IsNotNull();
            Check.That(this.imageResourceService.GetThumbnail(11)).IsNotNull();
            Check.That(this.imageResourceService.GetThumbnail(12)).IsNotNull();
            Check.That(this.imageResourceService.GetThumbnail(13)).IsNotNull();
        }

        [Test]
        public void ShouldGetShotImage()
        {
            Check.That(this.imageResourceService.GetImage(10)).IsNotNull();
            Check.That(this.imageResourceService.GetImage(11)).IsNotNull();
            Check.That(this.imageResourceService.GetImage(12)).IsNotNull();
            Check.That(this.imageResourceService.GetImage(13)).IsNotNull();
        }
    }
}
