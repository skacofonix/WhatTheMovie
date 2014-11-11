﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTM.Core.Application;

namespace WTM.Test.Application
{
    [TestClass]
    public class HtmlParserTest
    {
        [TestMethod]
        public void WhenGoodStreamThenParseCorrectly()
        {
            IHtmlParser htmlParser = new HtmlParser();
            IWebClient webClient = new StubWebClientShot();
            var stream = webClient.GetStream(null);

            //var htmlDoc = htmlParser.GetHtmlDocument(stream);

            //Check.That(htmlDoc).IsInstanceOf<HtmlDocument>();
        }
    }
}
