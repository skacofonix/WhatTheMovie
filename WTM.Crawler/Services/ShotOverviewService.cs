using System;
using WTM.Crawler.Domain;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Services
{
    public class ShotOverviewService : ShotService, IShotOverviewService
    {
        public ShotOverviewService(IWebClient webClient, IHtmlParser htmlParser, IImageDownloader imageDownloader, IImageRepository imageRepository)
            : base(webClient, htmlParser)
        {
            OverviewShotParser = new OverviewShotParser(webClient, htmlParser, imageDownloader, imageRepository);
        }

        protected readonly OverviewShotParser OverviewShotParser;

        public ShotSummaryCollection GetShotSummaryByDate(DateTime date, string token = null)
        {
            return OverviewShotParser.ParseByDate(date, token);
        }
    }
}