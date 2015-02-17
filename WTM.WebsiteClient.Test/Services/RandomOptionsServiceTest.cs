using NFluent;
using NUnit.Framework;
using WTM.Domain;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Services;

namespace WTM.WebsiteClient.Test.Services
{
    [TestFixture]
    public class RandomOptionsServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private RandomOptionsService randomOptionsService;

        [SetUp]
        public void BeforeTest()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            randomOptionsService = new RandomOptionsService(webClient, htmlParser);
        }

        [Test]
        public void WhenReadOptionsThenReturnEntity()
        {
            var difficultyOptions = randomOptionsService.Read();

            Check.That(difficultyOptions).IsNotNull();
            Check.That(difficultyOptions.NumberOfShotEasy).IsNotNull();
            Check.That(difficultyOptions.NumberOfShotMedium).IsNotNull();
            Check.That(difficultyOptions.NumberOfShotHard).IsNotNull();
        }

        [Test]
        public void WhenWriteOptionsThenWorks()
        {
            var difficultyOptions = new DifficultyOptions();
            difficultyOptions.SnapshotDifficultyFilter = new SnapshotDifficultyChoiceEasyMedium();
            difficultyOptions.TagFilter = "redhead";
            difficultyOptions.IncludeArchive = true;
            difficultyOptions.IncludeSolvedShots = true;

            Check.That(randomOptionsService.Write(difficultyOptions)).IsTrue();
        }
    }
}