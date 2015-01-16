using System;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Services
{
    internal class ShotArchiveService : ShotService
    {
        protected override string PageIdentifier { get { return "overview"; } }

        public ShotArchiveService(IWebClient webClient, IHtmlParser htmlParser) : base(webClient, htmlParser)
        {
            overviewShotParser = new OverviewShotParser(webClient, htmlParser);
        }

        private readonly OverviewShotParser overviewShotParser;

        public OverviewShotCollection GetArhciveOneMonthOld()
        {
            return overviewShotParser.ParseArchiveOneMonthOld();
        }
    }
}
