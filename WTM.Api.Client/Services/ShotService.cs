using System;
using System.Net;
using System.Net.Http;
using WTM.Api.Client.Helpers;
using WTM.Common.Helpers;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Api.Client.Services
{
    public class ShotService : IShotService
    {
        private readonly Uri baseUri;
        private readonly HttpClient httpClient;

        public ShotService(ISettings settings)
        {
            baseUri = new Uri(settings.Host, "shot/");
            httpClient = new HttpClient();
        }

        public Shot GetRandomShot(string token = null)
        {
            Shot shot = null;

            shot = httpClient.GetObjectSync<Shot>(baseUri);

            return shot;
        }

        public Shot GetById(int id, string token = null)
        {
            Shot shot = null;

            var uri = new Uri(baseUri, id.ToString());

            shot = httpClient.GetObjectSync<Shot>(uri);

            return shot;
        }

        public GuessTitleResponse GuessTitle(int id, string title, string token = null)
        {
            GuessTitleResponse guessTitleResponse = null;

            var requestBuilder = new HttpRequestBuilder(id.ToString());
            requestBuilder.AddParameter("guessTitle", WebUtility.UrlEncode(title));
            if(token != null)
                requestBuilder.AddParameter("token", token);

            var uri = new Uri(baseUri, requestBuilder.ToString());

            guessTitleResponse = httpClient.GetObjectSync<GuessTitleResponse>(uri);

            return guessTitleResponse;
        }

        public GuessTitleResponse GetSolution(int id, string token = null)
        {
            GuessTitleResponse guessTitleResponse = null;

            var uri = new Uri(baseUri, string.Format("{0}/solution", id));

            guessTitleResponse = httpClient.GetObjectSync<GuessTitleResponse>(uri);

            return guessTitleResponse;
        }

        public Rate Rate(int id, int score, string token = null)
        {
            Rate rate = null;

            var requestBuilder = new HttpRequestBuilder(id.ToString());
            requestBuilder.AddParameter("rate", score.ToString());
            if (token != null)
                requestBuilder.AddParameter("token", token);

            var uri = new Uri(baseUri, requestBuilder.ToString());

            rate = httpClient.GetObjectSync<Rate>(uri);

            return rate;
        }

        public ShotSummaryCollection Search(string tag, int? page = null, string token = null)
        {
            ShotSummaryCollection shotSummaryCollection = null;

            var requestBuilder = new HttpRequestBuilder();
            requestBuilder.AddParameter("search", WebUtility.UrlEncode(tag));
            if (page.HasValue)
                requestBuilder.AddParameter("page", page.GetValueOrDefault(1).ToString());
            if (token != null)
                requestBuilder.AddParameter("token", token);

            var uri = new Uri(baseUri, requestBuilder.ToString());

            shotSummaryCollection = httpClient.GetObjectSync<ShotSummaryCollection>(uri);

            return shotSummaryCollection;
        }
    }
}