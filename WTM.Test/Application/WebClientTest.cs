using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using WTM.Core.Application;

namespace WTM.Test.Application
{
    [TestClass]
    public class WebClientTest
    {
        [TestMethod]
        public void WhenGoogleUriThenReturnStream()
        {
            IWebClient webClient = new WebClient();
            var uriBuilder = new UriBuilder("http", "www.google.fr");
            var uri = uriBuilder.Uri;

            using (var stream = webClient.GetStream(uri))
            {
                Check.That(stream).IsNotNull();
            }
        }

        [TestMethod]
        public void WhenWhatTheMovieWebSiteUriThenReturnStream()
        {
            IWebClient webClient = new WebClient();
            var uriBuilder = new UriBuilder("http", "www.whatthemovie.com");
            var uri = uriBuilder.Uri;

            using (var stream = webClient.GetStream(uri))
            {
                Check.That(stream).IsNotNull();
            }
        }

        [TestMethod]
        public void WhenFakeWebClientReturnMockStream()
        {
            IWebClient webClient = new StubWebClient();

            using (var stream = webClient.GetStream(null))
            {
                Check.That(stream).IsNotNull();
            }
        }
    }
}