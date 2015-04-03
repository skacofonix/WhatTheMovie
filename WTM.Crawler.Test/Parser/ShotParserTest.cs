using NFluent;
using NUnit.Framework;
using WTM.Crawler.Parsers;
using WTM.Crawler.Services;

namespace WTM.Crawler.Test.Parser
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
            //webClient = new WebClientFake(Resources.shot10);
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            parser = new ShotParser(webClient, htmlParser);

            var authenticateService = new AuthenticateService(webClient, htmlParser);
            authenticateService.Login("captainOblivious", "captainOblivious");
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var shot = parser.GetById(1000);

            Check.That(shot.ShotId).Equals(1000);
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
