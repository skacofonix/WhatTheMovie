using System;
using NFluent;
using NUnit.Framework;
using WTM.Crawler.Services;

namespace WTM.Crawler.Test.Services
{
    [TestFixture]
    public class ImageDownloaderTest
    {
        [Test]
        public void ShouldDownloadImageFromWeb()
        {
            var downloader = new ImageDownloader(new WebClientWTM());

            var image = new Uri("http://static0.whatthemovie.net/system/images/stills/normal/b8/fdb59205e88bb4c0980072ff86d824.jpg");
            var referer = "http://whatthemovie.com/shot/10";

            var rawData = downloader.Get(image, referer);

            Check.That(rawData).IsNotNull();
        }
    }
}
