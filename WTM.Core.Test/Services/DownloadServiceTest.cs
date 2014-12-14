using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.Core.Services;

namespace WTM.Core.Test.Services
{
    [TestFixture]
    public class DownloadServiceTest
    {
        private IWebClient webClient;
        private DownloadService downloadService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            downloadService = new DownloadService(webClient);
        }

        [Test]
        public void WhenDownloadWhenReturnObject()
        {
            const string relativeImagePath = "/system/images/stills/normal/b8/fdb59205e88bb4c0980072ff86d824.jpg";
            var uri = new Uri(webClient.UriBase, relativeImagePath);
            var destinationFile = Path.GetTempFileName();

            Check.ThatCode(() => downloadService.Download(uri, destinationFile)).DoesNotThrow();
        }
    }
}
