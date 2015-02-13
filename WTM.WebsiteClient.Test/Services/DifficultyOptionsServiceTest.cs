using NFluent;
using NUnit.Framework;
using WTM.Domain;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Services;

namespace WTM.WebsiteClient.Test.Services
{
    [TestFixture]
    public class DifficultyOptionsServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private DifficultyOptionsService difficultyOptionsService;


        [SetUp]
        public void BeforeTest()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            difficultyOptionsService = new DifficultyOptionsService(webClient, htmlParser);

            var authentifier = new Authentifier(webClient, htmlParser);
            if (authentifier.Login("captainOblivious", "captainOblivious"))
                webClient.SetCookie(authentifier.CookieSession);
        }

        [Test]
        public void WhenReadOptionsThenReturnEntity()
        {
            var difficultyOptions = difficultyOptionsService.Read();

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

            Check.That(difficultyOptionsService.Write(difficultyOptions)).IsTrue();
        }
    }
}