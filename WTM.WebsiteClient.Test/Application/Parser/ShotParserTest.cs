using NFluent;
using NUnit.Framework;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;

namespace WTM.WebsiteClient.Test.Application.Parser
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
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            parser = new ShotParser(webClient, htmlParser);
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var shot = parser.Parse(10);

            Check.That(shot.Navigation.FirstId).HasAValue();
            Check.That(shot.Navigation.LastId).HasAValue();
            Check.That(shot.Navigation.PreviousId).HasAValue();
            Check.That(shot.Navigation.PreviousUnsolvedId).HasAValue();
            Check.That(shot.Navigation.NextId).HasAValue();
            Check.That(shot.Navigation.NextUnsolvedId).HasAValue();
            Check.That(shot.Poster).IsNotNull();
            Check.That(shot.ImageUri).IsNotNull();
        }
    }
}
