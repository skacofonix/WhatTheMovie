using System.Collections.Generic;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class ShotController : BaseController
    {
        private readonly IShotService shotService;

        public ShotController()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            shotService = new ShotService(webClient, htmlParser);
        }

        public ShotController(IShotService shotService)
        {
            this.shotService = shotService;
        }

        //public ShotResponse Get([FromBody]string token = null)
        //{
        //    return DoWork(() =>
        //    {
        //        var shotResponse = new ShotResponse();

        //        var shot = shotService.GetRandomShot(token);

        //        if (shot != null)
        //        {
        //            shotResponse.Shot = shot;
        //        }
        //        else
        //        {
        //            shotResponse.AddError(new Error
        //            {
        //                Message = "Error occured on the server-side API"
        //            });
        //        }

        //        return shotResponse;
        //    });
        //}

        /// <summary>
        /// Return Shot identified by ID.
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Token</param>
        /// <returns></returns>
        /// <response code="400">Bad request</response>
        /// <response code="404">Shot not found</response>
        /// <response code="500">Internal Server Error</response>
        public ShotResponse Get(int id, [FromBody]string token = null)
        {
            return DoWork(() =>
            {
                var shotResponse = new ShotResponse();

                var shot = shotService.GetById(id, token);

                if (shot != null)
                {
                    shotResponse.Shot = shot;
                }
                else
                {
                    shotResponse.AddError(new Error
                    {
                        Message = "This shot doesn't exist"
                    });
                }

                return shotResponse;
            });
        }

        public IEnumerable<Shot> Get(Token token)
        {
            return new List<Shot>();
        }

        public IEnumerable<Shot> FindByTag(string tag)
        {
            return new List<Shot>();
        }

        //public ShotGuessTitleResponse GuessSolution([FromUri]int id, [FromBody]string guessTitle, [FromBody]string token = null)
        //{
        //    return DoWork(() =>
        //    {
        //        var response = new ShotGuessTitleResponse();

        //        var guessTitleResponse = shotService.GuessTitle(id, guessTitle, token);

        //        if (guessTitleResponse != null)
        //        {
        //            response.GuessTitleResponse = guessTitleResponse;
        //        }
        //        else
        //        {
        //            response.AddError(new Error
        //            {
        //                Message = "Error occured on the server-side API"
        //            });
        //        }

        //        return response;
        //    });

        //}

        //public ShotGuessTitleResponse GetSolution([FromUri]int id, [FromBody]string token = null)
        //{
        //    return DoWork(() =>
        //    {
        //        var response = new ShotGuessTitleResponse();

        //        var guessTitleResponse = shotService.GetSolution(id, token);

        //        if (guessTitleResponse != null)
        //        {
        //            response.GuessTitleResponse = guessTitleResponse;
        //        }
        //        else
        //        {
        //            response.AddError(new Error
        //            {
        //                Message = "Error occured on the server-side API"
        //            });
        //        }

        //        return response;
        //    });
        //}

        //public ShotRateResponse Rate([FromUri]int id, [FromBody]int rate, [FromBody]string token = null)
        //{
        //    return DoWork(() =>
        //    {
        //        var response = new ShotRateResponse();

        //        var rateResponse = shotService.Rate(id, rate, token);

        //        if (rateResponse != null)
        //        {
        //            response.Rate = rateResponse;
        //        }
        //        else
        //        {
        //            response.AddError(new Error
        //            {
        //                Message = "Error occured on the server-side API"
        //            });
        //        }

        //        return response;
        //    });
        //}

        //public ShotSearchResult Search([FromBody]string search, [FromBody] int? page, [FromBody]string token = null)
        //{
        //    return DoWork(() =>
        //    {
        //        var response = new ShotSearchResult();

        //        var shotSummaryCollection = shotService.Search(search, page, token);

        //        if (shotSummaryCollection != null)
        //        {
        //            response.ShotSummaries = shotSummaryCollection;
        //        }
        //        else
        //        {
        //            response.AddError(new Error
        //            {
        //                Message = "Error occured on the server-side API"
        //            });
        //        }

        //        return response;
        //    });
        //}

        //public HttpResponseMessage GetImage([FromBody]string image, [FromBody] string referer)
        //{
        //    var uriImage = new Uri(WebUtility.UrlDecode(image));

        //    var webClient = new System.Net.WebClient();
        //    webClient.Headers = new WebHeaderCollection();
        //    webClient.Headers["Referer"] = WebUtility.UrlDecode(referer);

        //    var stream = webClient.OpenRead(uriImage);
        //    var ms = new MemoryStream();
        //    stream.CopyTo(ms);

        //    var result = new HttpResponseMessage(HttpStatusCode.OK);
        //    result.Content = new ByteArrayContent(ms.ToArray());
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

        //    return result;
        //}
    }

    public class Token
    {
        public string Value { get; set; }
    }
}