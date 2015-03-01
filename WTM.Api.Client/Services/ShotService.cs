using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Api.Client.Services
{
    public class ShotService : IShotService
    {
        private readonly Uri baseUri;
        private readonly HttpClient httpClient;

        public ShotService()
        {
            UriBuilder uriBuilder;
            uriBuilder = new UriBuilder("http", "localhost", 56369, "api/shot/");
            //uriBuilder = new UriBuilder("https", "wtmapi.azurewebsites.net", 443, "api/shot/");

            baseUri = uriBuilder.Uri;

            httpClient = new HttpClient();
        }

        public Shot GetRandomShot()
        {
            Shot shot = null;

            var uri = baseUri;

            var task = httpClient.GetStringAsync(uri).ContinueWith(result =>
            {
                var json = JObject.Parse(result.Result);
                var jsonReader = json.CreateReader();
                var jsonSerialializer = JsonSerializer.Create();
                var shotDesrialized = jsonSerialializer.Deserialize<Shot>(jsonReader);
                shot = shotDesrialized;
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
                var json = JObject.Parse(result.Result);
                var jsonReader = json.CreateReader();
                var jsonSerialializer = JsonSerializer.Create();
                var shotDesrialized = jsonSerialializer.Deserialize<Shot>(jsonReader);
                shot = shotDesrialized;
            });

            task.Wait();

            return shot;
        }

        public GuessTitleResponse GuessTitle(int shotId, string title)
        {
            GuessTitleResponse guessTitleResponse = null;
            
            var uri = new Uri(baseUri, string.Format("{0}&guessTitle={1}",
                shotId,
                WebUtility.UrlEncode(title)));

            var content = string.Format("guessTitle='{0}'", WebUtility.UrlEncode(title));

            var task = httpClient.GetStringAsync(uri).ContinueWith(result =>
            {
                var json = JObject.Parse(result.Result);
                var jsonReader = json.CreateReader();
                var jsonSerialializer = JsonSerializer.Create();
                var shotDesrialized = jsonSerialializer.Deserialize<GuessTitleResponse>(jsonReader);
                guessTitleResponse = shotDesrialized;
            });

            task.Wait();

            return guessTitleResponse;
        }

        public Movie ShowSolution(int shotId)
        {
            throw new NotImplementedException();
        }

        public Rate Rate(int score)
        {
            throw new NotImplementedException();
        }

        public ShotSummaryCollection Search(string tag, int? page = null)
        {
            throw new NotImplementedException();
        }
    }
}
