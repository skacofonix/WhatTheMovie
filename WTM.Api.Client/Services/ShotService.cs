using System;
using System.Net;
using System.Net.Http;
using WTM.Api.Client.Helpers;
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

        public Shot GetRandomShot()
        {
            Shot shot = null;

            shot = httpClient.GetObjectSync<Shot>(baseUri);

            return shot;
        }

        public Shot GetById(int id)
        {
            Shot shot = null;

            var uri = new Uri(baseUri, id.ToString());

            shot = httpClient.GetObjectSync<Shot>(uri);

            return shot;
        }

        public GuessTitleResponse GuessTitle(int id, string title)
        {
            GuessTitleResponse guessTitleResponse = null;

            var uri = new Uri(baseUri, string.Format("{0}?guessTitle={1}", id,WebUtility.UrlEncode(title)));

            guessTitleResponse = httpClient.GetObjectSync<GuessTitleResponse>(uri);

            return guessTitleResponse;
        }

        public GuessTitleResponse GetSolution(int id)
        {
            GuessTitleResponse guessTitleResponse = null;

            var uri = new Uri(baseUri, string.Format("{0}/solution", id));

            guessTitleResponse = httpClient.GetObjectSync<GuessTitleResponse>(uri);

            return guessTitleResponse;
        }

        public Rate Rate(int id, int score)
        {
            Rate rate = null;

            var uri = new Uri(baseUri, string.Format("{0}?rate={1}", id, score));

            rate = httpClient.GetObjectSync<Rate>(uri);

            return rate;
        }

        public ShotSummaryCollection Search(string tag, int? page = null)
        {
            ShotSummaryCollection shotSummaryCollection = null;

            var uri = new Uri(baseUri, string.Format("?search={0}&page={1}", WebUtility.UrlEncode(tag), page));

            shotSummaryCollection = httpClient.GetObjectSync<ShotSummaryCollection>(uri);

            return shotSummaryCollection;
        }
    }
}