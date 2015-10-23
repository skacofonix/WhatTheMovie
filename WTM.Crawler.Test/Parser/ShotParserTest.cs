using NFluent;
using NUnit.Framework;
using WTM.Crawler.Domain;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Test.Parser
{
    [TestFixture]
    public class ShotParserTest
    {
        [Test]
        public void ShouldParseShotPage()
        {
            var shot1 = ParseShotAndDoBasicCheck(1);
            Check.That(shot1.Navigation.PreviousId).IsNull();
            Check.That(shot1.Navigation.PreviousUnsolvedId).IsNull();
            Check.That(shot1.IsSolutionAvailable.GetValueOrDefault(false)).IsTrue();
            Check.That(shot1.NumberOfDayBeforeSolution).IsNull();

            ParseShotAndDoBasicCheck(10);

            ParseShotAndDoBasicCheck(350532);

            var shot352612 =  ParseShotAndDoBasicCheck(352612);
            Check.That(shot352612.UserStatus).Equals(ShotUserStatus.Unsolved);

            var shot353243 = ParseShotAndDoBasicCheck(353243);
            Check.That(shot353243.IsSolutionAvailable.GetValueOrDefault(true)).IsFalse();
            Check.That(shot353243.NumberOfDayBeforeSolution).IsNotNull();
        }

        [Test]
        public void ShouldParseNerverSolvedShotPage()
        {
            var shot350523 = ParseShotAndDoBasicCheck(350523);
            Check.That(shot350523.FirstSolver).IsNull();
            Check.That(shot350523.UserStatus).Equals(ShotUserStatus.NeverSolved);
        }

        private Shot ParseShotAndDoBasicCheck(int shotId)
        {
            var shot = ParseFakeShot(shotId);

            Check.That(shotId).Equals(shot.ShotId);
            Check.That(shot.Poster).IsNotNull();
            Check.That(shot.ImageUri).IsNotNull();
            Check.That(shot.Navigation).IsNotNull();
            Check.That(shot.UserStatus).IsNotNull();

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