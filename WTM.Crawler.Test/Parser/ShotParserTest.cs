using NFluent;
using NUnit.Framework;
using WTM.Crawler.Parsers;
using WTM.Domain;

namespace WTM.Crawler.Test.Parser
{
    [TestFixture]
    public class ShotParserTest
    {
        [Test]
        public void WhenParseOfflineShotPageThenReturnValidEntity()
        {
            ParseShotAndDoBasicCheck(1);
            ParseShotAndDoBasicCheck(10);
            ParseShotAndDoBasicCheck(350523);
            ParseShotAndDoBasicCheck(350532);
            var shot352612 =  ParseShotAndDoBasicCheck(352612);
            Check.That(shot352612.FirstSolver).IsNull();
            Check.That(shot352612.UserStatus).Equals(ShotUserStatus.NeverSolved);

            ParseShotAndDoBasicCheck(353243);
        }

        private Shot ParseShotAndDoBasicCheck(int shotId)
        {
            var shot = ParseFakeShot(shotId);

            Check.That(shotId).Equals(shot.ShotId);
            Check.That(shot.Poster).IsNotNull();
            Check.That(shot.ImageUri).IsNotNull();

            return shot;
        }

        private Shot ParseFakeShot(int shotId)
        {
            var resourceName = string.Format("Resources/Shots/{0}.html", shotId);
            return CreateParserWithFakeFile(resourceName).GetById(shotId);
        }

        private ShotParser CreateParserWithFakeFile(string htmlFilePath)
        {
            return new ShotParser(new WebClientFake(htmlFilePath), new HtmlParser());
        }
    }
}