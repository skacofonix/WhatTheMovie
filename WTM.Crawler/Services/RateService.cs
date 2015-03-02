using System;
using System.Globalization;
using WTM.Crawler.Helpers;

namespace WTM.Crawler.Services
{
    public class RateService
    {
        private readonly IWebClient webClient;

        public RateService(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public void RateMovie(int id, int rated, bool rerated = false)
        {
            Rate("movie", id.ToString(CultureInfo.InvariantCulture), rated, rerated);
        }

        public void RateShot(string id, int rated, bool rerated = false)
        {
            Rate("shot", id, rated, rerated);
        }

        private void Rate(string category, string id, int rate, bool rerated)
        {
            var uri = new Uri(string.Join("/", webClient.UriBase, category, id, "rate.js"));

            //average=2.5&identity=shot_rating_stars_344103&max=5&rated=2.5&rerated=true&total=1

            var blop = new HttpRequestBuilder();
            blop.AddParameter("average", "");
            blop.AddParameter("identity", "");
            blop.AddParameter("max", "");
            blop.AddParameter("rated", "");
            blop.AddParameter("rerated", rerated ? "true" : "false");
            blop.AddParameter("total", "1");
        }
    }

    public class PostRate
    {
        public decimal Average { get; set; }
        public string Identity { get; set; }
        public decimal Max { get; set; }
        public decimal Rated { get; set; }
        public int Total { get; set; }
    }
}
