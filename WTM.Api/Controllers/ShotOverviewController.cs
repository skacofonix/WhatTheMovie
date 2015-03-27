using System;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class ShotOverviewController : ApiController
    {
        private readonly IShotOverviewService shotOverviewService;

        public ShotOverviewController()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            shotOverviewService = new ShotOverviewService(webClient, htmlParser);
        }

        [HttpGet]
        [Route("api/ShotOverview/{year}/{month}/{day}")]
        public ShotSummaryCollection Get([FromUri] int year, [FromUri] int month, [FromUri] int day)
        {
            ShotSummaryCollection shotSummaryCollection = null;
            DateTime? date;

            try
            {
                  date = new DateTime(year, month, day);
            }
            catch (Exception)
            {
                // ToDo : Log + Use encapsulate WS type
                date = null;
            }

            if (date.HasValue)
                shotSummaryCollection = shotOverviewService.GetShotSummaryByDate(date.Value);

            return shotSummaryCollection;
        }
    }
}