﻿using NFluent;
using NUnit.Framework;
using WTM.Crawler.Services;

namespace WTM.Crawler.Test.Services
{
    [TestFixture]
    public class MovieServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private MovieService movieService;

        [SetUp]
        public void BeforeTest()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            movieService = new MovieService(webClient, htmlParser);
        }

        [Test]
        public void WhenGetMovieByTitleThenReturnEntity()
        {
            var movie = movieService.GetById("eternal_sunshine_of_the_spotless_mind");

            Check.That(movie).IsNotNull();
            Check.That(movie.ParseDateTime).IsNotEqualTo(null);
            Check.That(movie.OriginalTitle).IsNotNull();
            Check.That(movie.GenreList).IsNotNull();
            Check.That(movie.Director).IsNotNull();
            Check.That(movie.Abstract).IsNotNull();
            Check.That(movie.Year).IsNotNull();
            Check.That(movie.Rate).IsNotNull();
            Check.That(movie.Rate).IsNotNull();
            Check.That(movie.AlternativeTitles).IsNotNull();
            Check.That(movie.Tags).IsNotNull();
            Check.That(movie.NumberOfSnapshot).IsNotNull();
            Check.That(movie.TotalSolves).IsNotNull();
            Check.That(movie.IntroducedOn).IsNotNull();
            Check.That(movie.IntroducedBy).IsNotNull();
            Check.That(movie.NumberOfReviews).IsNotNull();
        }

        [Test]
        public void WhenSearchMovieThenReturnEntities()
        {
            var movies = movieService.Search("eternal");
            Check.That(movies).IsNotNull();
        }
    }
}