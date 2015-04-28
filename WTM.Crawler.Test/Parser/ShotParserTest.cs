using NFluent;
using NUnit.Framework;
using WTM.Crawler.Parsers;
using WTM.Crawler.Services;
using WTM.Domain;

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
            var shot1000 = ParseShotAndDoBasicCheck(1000);
            Check.That(shot1000.Navigation.PreviousUnsolvedId).HasAValue();

            var shot10 = ParseShotAndDoBasicCheck(10);
            Check.That(shot10.IsSolutionAvailable.GetValueOrDefault()).IsTrue();
        }

        private Shot ParseShotAndDoBasicCheck(int shotId)
        {
            var shot = parser.GetById(shotId);

            Check.That(shot.ShotId).Equals(shotId);
            Check.That(shot.Navigation.FirstId).HasAValue();
            Check.That(shot.Navigation.LastId).HasAValue();
            Check.That(shot.Navigation.PreviousId).HasAValue();
            Check.That(shot.Navigation.NextId).HasAValue();
            Check.That(shot.Navigation.NextUnsolvedId).HasAValue();
            Check.That(shot.Poster).IsNotNull();
            Check.That(shot.ImageUri).IsNotNull();

            return shot;
        }
    }
}