using System;
using System.Net.Http;
using WTM.Api.Client.Helpers;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Api.Client.Services
{
    public class MovieService : IMovieService
    {
        private readonly Uri baseUri;
        private readonly HttpClient httpClient;

        public MovieService(ISettings settings)
        {
            baseUri = new Uri(settings.Host, "movie/");
            httpClient = new HttpClient();
        }

        public Movie GetByTitle(string title)
        {
            Movie movie = null;

            var task = httpClient.GetStringAsync(baseUri).ContinueWith(result =>
            {
                movie = result.Result.Deserialize<Movie>();
            });

            task.Wait();

            return movie;
        }

        public MovieSummaryCollection Search(string title, int? page = null)
        {
            MovieSummaryCollection movieSummaryCollection = null;

            var task = httpClient.GetStringAsync(baseUri).ContinueWith(result =>
            {
                movieSummaryCollection = result.Result.Deserialize<MovieSummaryCollection>();
            });

            task.Wait();


            return movieSummaryCollection;
        }
    }
}
