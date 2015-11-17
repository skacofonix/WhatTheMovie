using System;
using System.Net.Http;
using WTM.Api.Client.Helpers;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Domain.OldSchool;

namespace WTM.Api.Client.Services
{
    public class ShotOverviewService : IShotOverviewService
    {
        private readonly Uri baseUri;
        private readonly HttpClient httpClient;
        private readonly ImageDownloadUriMaker imageDownloadUriMaker;

        public ShotOverviewService(ISettings settings)
        {
            baseUri = new Uri(settings.Host, "ShotOverview/");
            httpClient = new HttpClient();
            imageDownloadUriMaker = new ImageDownloadUriMaker(settings.Host);
        }

        public ShotSummaryCollection GetShotSummaryByDate(DateTime date)
        {
            ShotSummaryCollection shotSummaryCollection = null;

            var uri = new Uri(baseUri, string.Join("/", date.Year, date.Month, date.Day));

            var response = httpClient.GetObjectSync<ShotOverviewResponse>(uri);

            if (response != null && !response.HasError)
            {
                shotSummaryCollection = response.ShotsSummaries;

                foreach (var shot in shotSummaryCollection.Shots)
                {
                    shot.ImageUri = imageDownloadUriMaker.MakeUri(shot.ImageUri, string.Join("/", "http://whatthemovie.com/overview", date.Year, date.Month, date.Day));
                }
            }

            return shotSummaryCollection;
        }
    }
}