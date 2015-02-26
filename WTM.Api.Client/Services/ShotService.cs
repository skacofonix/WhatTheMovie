using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
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
            var uriBuilder = new UriBuilder("http", "localhost", 56369, "api/");
            baseUri = uriBuilder.Uri;

            httpClient = new HttpClient();
        }

        public Shot GetRandomShot()
        {
            Shot shot = null;

            var uri = new Uri(baseUri, "shot");

            try
            {
                var task = httpClient.GetStringAsync(uri).ContinueWith(result =>
                {
                    var json = JObject.Parse(result.Result);
                    var jsonReader = json.CreateReader();
                    var jsonSerialializer = JsonSerializer.Create();
                    var shotDesrialized = jsonSerialializer.Deserialize<Shot>(jsonReader);
                    shot = shotDesrialized;
                }, TaskContinuationOptions.NotOnCanceled);

                task.Wait();
            }
            catch (Exception ex)
            {
                throw;
            }

            
            return shot;
        }

        private async Task<string>GetRandomShotString(Uri uri)
        {
            var s =  await httpClient.GetStringAsync(uri);
            return s;
        }

        public Shot GetShotById(int id)
        {
            throw new NotImplementedException();
        }

        public GuessTitleResponse GuessTitle(int shotId, string title)
        {
            throw new NotImplementedException();
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
