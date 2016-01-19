using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public class ShotFeatureFilmsService : ShotOverviewService, IShotFeatureFilmsService
    {
        public ShotFeatureFilmsService(IWebClient webClient, IHtmlParser htmlParser, IImageDownloader imageDownloader, IImageRepository imageRepository)
            : base(webClient, htmlParser, imageDownloader, imageRepository)
        { }

        public ShotSummaryCollection GetShotSummaryToday(string token = null)
        {
            return OverviewShotParser.ParseFeatureFilmsToday(token);
        }
    }
}