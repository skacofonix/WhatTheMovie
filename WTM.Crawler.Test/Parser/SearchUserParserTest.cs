using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Test.Parser
{
    [TestFixture]
    public class SearchUserParserTest
    {
        [Test]
        public void ShouldSearchUser()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            var searcher = new SearchUserParser(webClient, htmlParser);

            var result = searcher.Search("ama");

            Check.That(result).IsNotNull();
        }
    }
}
