using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTM.Core.Application;
using HtmlAgilityPack;
using System.Linq;

namespace WTM.Test.Application
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebClient webClient = new WebClient();
            IHtmlParser htmlParser = new HtmlParser();

            var uriBuilder = new UriBuilder("http", "www.whatthemovie.com", 80, "shot/10");
            var uri = uriBuilder.Uri;

            HtmlDocument document = null;
            using (var stream = webClient.GetStream(uri))
            {
                document = htmlParser.GetHtmlDocument(stream);
            }
            document.DocumentNode.SelectNodes("//div[@id='main_shot']/div[@id='hidden_date']").FirstOrDefault();

        }
    }
}
