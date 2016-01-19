using NFluent;
using NUnit.Framework;
using System.Linq;
using WTM.Crawler.Parsers;
using WTM.Crawler.Services;

namespace WTM.Crawler.Test.Parser
{
    [TestFixture]
    public class OverviewShotParserTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private IImageDownloader imageDownloader;
        private IImageRepository imageRepository;
        private OverviewShotParser parser;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientFake("Resources/FeatureFilms/FeatureFilms20141201.html");
            htmlParser = new HtmlParser();
            imageDownloader = new ImageDownloader(webClient);
            imageRepository = new ImageRepository();

            parser = new OverviewShotParser(webClient, htmlParser, imageDownloader, imageRepository);
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var featureFilm = parser.ParseOverviewShotByDate();

            Check.That(featureFilm).IsNotNull();
            Check.That(featureFilm.Date).IsNotNull();
            Check.That(featureFilm.Shots).IsNotNull();
            Check.That(featureFilm.Shots.Any()).IsTrue();
        }
    }
}