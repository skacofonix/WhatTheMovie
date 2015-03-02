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

        public Shot GetShotById(int id)
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

            var uri = new Uri(baseUri, id.ToString());

            var content = string.Format("title='{0}'", WebUtility.UrlEncode(title));

            var taskPostAsync = httpClient.PostAsync(uri, new StringContent(content))
                .ContinueWith(resultPostAsync =>
                {
                    var taskReadAsync = resultPostAsync.Result.Content.ReadAsStringAsync()
                        .ContinueWith(resultReadAsync =>
                        {
                            guessTitleResponse = resultReadAsync.Result.Deserialize<GuessTitleResponse>();
                        });

                    taskReadAsync.Wait();
                });

            taskPostAsync.Wait();

            return guessTitleResponse;
        }

        public GuessTitleResponse ShowSolution(int id)
        {
            throw new NotImplementedException();
        }

        public Rate Rate(int id, int score)
        {
            throw new NotImplementedException();
        }

        public ShotSummaryCollection Search(string tag, int? page = null)
        {
            throw new NotImplementedException();
        }
    }
}
