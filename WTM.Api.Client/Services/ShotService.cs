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

            var task = httpClient.GetStringAsync(baseUri).ContinueWith(result =>
            {
                shot = result.Result.Deserialize<Shot>();
            });

            task.Wait();

            return shot;
        }

        public Shot GetById(int id)
        {
            Shot shot = null;

            var uri = new Uri(baseUri, id.ToString());

            var task = httpClient.GetStringAsync(uri).ContinueWith(result =>
            {
                shot = result.Result.Deserialize<Shot>();
            });

            task.Wait();

            return shot;
        }

        public GuessTitleResponse GuessTitle(int id, string title)
        {
            GuessTitleResponse guessTitleResponse = null;

            var uri = new Uri(baseUri, string.Format("{0}?guessTitle={1}", id,WebUtility.UrlEncode(title)));

            var task = httpClient.GetStringAsync(uri).ContinueWith(result =>
            {
                guessTitleResponse = result.Result.Deserialize<GuessTitleResponse>();
            });
            task.Wait();

            return guessTitleResponse;
        }

        public GuessTitleResponse GetSolution(int id)
        {
            GuessTitleResponse guessTitleResponse = null;

            var uri = new Uri(baseUri, string.Format("{0}/solution", id));

            var task = httpClient.GetStringAsync(uri).ContinueWith(result =>
            {
                guessTitleResponse = result.Result.Deserialize<GuessTitleResponse>();
            });
            task.Wait();

            return guessTitleResponse;
        }

        public Rate Rate(int id, int score)
        {
            throw new NotImplementedException();
        }

        public ShotSummaryCollection Search(string tag, int? page = null)
        {
            ShotSummaryCollection shotSummaryCollection = null;

            var uri = new Uri(baseUri, string.Format("?search={0}&page={1}", WebUtility.UrlEncode(tag), page));

            var task = httpClient.GetStringAsync(uri).ContinueWith(result =>
            {
                shotSummaryCollection = result.Result.Deserialize<ShotSummaryCollection>();
            });

            task.Wait();

            return shotSummaryCollection;
        }
    }
}
