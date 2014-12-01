using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Test.Properties;

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
            webClient = new WebClientFake(Resources.shot10);
            htmlParser = new HtmlParser();
            parser = new ShotParser(webClient, htmlParser);
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var shot = parser.Parse(10);

            Check.That(shot.FirstShotId).HasAValue();
            Check.That(shot.PreviousShotId).HasAValue();
            Check.That(shot.FirstShotId).HasAValue();
            Check.That(shot.NextShotId).HasAValue();
            Check.That(shot.LastShotId).HasAValue();

            Check.That(shot.PostedDate).IsNotNull();
            Check.That(shot.PostedBy).IsNotNull();
            Check.That(shot.NbSolver).HasAValue();
            Check.That(shot.ImageUrl).IsNotNull();
        }
    }
}
