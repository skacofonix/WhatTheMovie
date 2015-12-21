using System;
using System.Net;
using System.Net.Http;
using WTM.Api.Client.Helpers;
using WTM.Domain;
using WTM.Domain.OldSchool;

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

        public Movie GetById(string id)
        {
            Movie movie = null;
            
            var uri = new Uri(baseUri, WebUtility.UrlEncode(id));

            movie = httpClient.GetObjectSync<Movie>(uri);

            return movie;
        }

        public MovieSummaryCollection Search(string title, int? page = null)
        {
            MovieSummaryCollection movieSummaryCollection = null;

            var uri = new Uri(baseUri, string.Format("?search={0}&page={1}", WebUtility.UrlEncode(title), page));

            movieSummaryCollection = httpClient.GetObjectSync<MovieSummaryCollection>(uri);

            return movieSummaryCollection;
        }
    }
}
