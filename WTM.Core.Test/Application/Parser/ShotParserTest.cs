using System;
using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;

namespace WTM.Core.Test.Application.Parser
{
    [TestFixture]
    public class ShotParserTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private ShotParser parser;

        [SetUp]
        public void Init()
        {
            webClient = new WebClient(new Uri("http://whatthemovie.com"));
            htmlParser = new HtmlParser();
            parser = new ShotParser(webClient, htmlParser);
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var shot = parser.Parse(10);
            Check.That(shot).IsNotNull();
            Check.That(shot.ShotId).HasAValue();
            Check.That(shot.ShotId.GetValueOrDefault()).Equals(10);
            Check.That(shot.ImageUrl).IsNotNull();
        }
    }
}
