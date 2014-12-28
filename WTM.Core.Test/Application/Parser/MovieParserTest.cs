using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;

namespace WTM.Core.Test.Application.Parser
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
            var movie = movieParser.Parse("eternal_sunshine_of_the_spotless_mind");

            Check.That(movie).IsNotNull();
            Check.That(movie.ParseDateTime).IsNotEqualTo(null);
            Check.That(movie.OriginalTitle).IsNotNull();
            Check.That(movie.GenreList).IsNotNull();
            Check.That(movie.Director).IsNotNull();
        }
    }
}