using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public class ShotArchiveService : ShotOverviewService, IShotArchiveService
    {
        public ShotArchiveService(IWebClient webClient, IHtmlParser htmlParser, IImageDownloader imageDownloader, IImageRepository imageRepository)
            : base(webClient, htmlParser, imageDownloader, imageRepository)
        { }

        public ShotSummaryCollection GetArchiveOneMonthOld(string token = null)
        {
            return OverviewShotParser.ParseArchiveOneMonthOld(token);
        }
    }
}   