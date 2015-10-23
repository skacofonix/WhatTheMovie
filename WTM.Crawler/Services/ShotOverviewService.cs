using System;
using WTM.Crawler.Domain;
using WTM.Crawler.Parsers;

namespace WTM.Crawler.Services
{
    public class ShotOverviewService : ShotService, IShotOverviewService
    {
        public ShotOverviewService(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        {
            OverviewShotParser = new OverviewShotParser(webClient, htmlParser);
        }

        protected readonly OverviewShotParser OverviewShotParser;

        public ShotSummaryCollection GetShotSummaryByDate(DateTime date)
        {
            return OverviewShotParser.ParseByDate(date);
        }
    }
}