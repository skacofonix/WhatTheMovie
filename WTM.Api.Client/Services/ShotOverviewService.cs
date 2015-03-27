using System;
using System.Net.Http;
using WTM.Api.Client.Helpers;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Api.Client.Services
{
    public class ShotOverviewService : IShotOverviewService
    {
        private readonly Uri baseUri;
        private readonly HttpClient httpClient;

        public ShotOverviewService(ISettings settings)
        {
            baseUri = new Uri(settings.Host, "ShotOverview/");
            httpClient = new HttpClient();
        }

        public ShotSummaryCollection GetShotSummaryByDate(DateTime date)
        {
            ShotSummaryCollection shotSummaryCollection = null;

            var uri = new Uri(baseUri, string.Join("/", date.Year, date.Month, date.Day));

            shotSummaryCollection = httpClient.GetObjectSync<ShotSummaryCollection>(uri);

            return shotSummaryCollection;
        }
    }
}