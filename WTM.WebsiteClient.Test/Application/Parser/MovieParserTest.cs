using NFluent;
using NUnit.Framework;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;

namespace WTM.WebsiteClient.Test.Application.Parser
{
    [TestFixture]
    public class MovieParserTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private MovieParser movieParser;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            movieParser = new MovieParser(webClient, htmlParser);
        }

        [Test]
        public void WhenParseThenReturnValidEntity()
        {
            var movie = movieParser.GetById("eternal_sunshine_of_the_spotless_mind");

            Check.That(movie).IsNotNull();
            Check.That(movie.ParseDateTime).IsNotEqualTo(null);
            Check.That(movie.OriginalTitle).IsNotNull();
            Check.That(movie.GenreList).IsNotNull();
            Check.That(movie.Director).IsNotNull();
            Check.That(movie.Abstract).IsNotNull();
            Check.That(movie.Year).IsNotNull();
            Check.That(movie.NumberOfRate).IsNotNull();
            Check.That(movie.AlternativeTitles).IsNotNull();
            Check.That(movie.Tags).IsNotNull();
            Check.That(movie.NumberOfSnapshot).IsNotNull();
            Check.That(movie.TotalSolves).IsNotNull();
            Check.That(movie.IntroducedOn).IsNotNull();
            Check.That(movie.IntroducedBy).IsNotNull();
            Check.That(movie.NumberOfReviews).IsNotNull();
        }
    }
}