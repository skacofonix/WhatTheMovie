using System;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class ShotOverviewController : BaseController
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
        public ShotOverviewResponse Get([FromUri] int year, [FromUri] int month, [FromUri] int day)
        {
            return DoWork(() =>
            {
                var response = new ShotOverviewResponse();

                DateTime? date;
                try
                {
                    date = new DateTime(year, month, day);
                }
                catch (Exception ex)
                {
                    date = null;
                    response.AddError(new Error
                    {
                        Message = "Invalid date",
                    });
                }

                if (date.HasValue)
                {
                    var shotSummaries = shotOverviewService.GetShotSummaryByDate(date.Value);

                    if (shotSummaries != null)
                    {
                        response.ShotsSummaries = shotSummaries;
                    }
                    else
                    {
                        response.AddError(DefaultError.DefaultApiError);
                    }
                }

                return response;
            });
        }
    }
}