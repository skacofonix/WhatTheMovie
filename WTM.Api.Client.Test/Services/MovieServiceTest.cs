using NFluent;
using NUnit.Framework;
using WTM.Api.Client.Services;
using WTM.Core.Services;

namespace WTM.Api.Client.Test.Services
{
    [TestFixture]
    public class MovieServiceTest
    {
        private IMovieService movieService;

        [SetUp]
        public void BeforeTest()
        {
            movieService = new MovieService(new SettingsProxy());
        }

        [Test]
        public void WhenGetMovieByTitleThenReturnEntity()
        {
            var movie = movieService.GetByTitle("eternal_sunshine_of_the_spotless_mind");

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
