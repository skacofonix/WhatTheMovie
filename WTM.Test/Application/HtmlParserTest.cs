using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTM.Core.Application;
using NFluent;
using HtmlAgilityPack;

namespace WTM.Test.Application
{
    [TestClass]
    public class HtmlParserTest
    {
        [TestMethod]
        public void WhenGoodStreamThenParseCorrectly()
        {
            IHtmlParser htmlParser = new HtmlParser();
            IWebClient webClient = new StubWebClient();
            var stream = webClient.GetStream(null);

            //var htmlDoc = htmlParser.GetHtmlDocument(stream);

            //Check.That(htmlDoc).IsInstanceOf<HtmlDocument>();
        }
    }
}
