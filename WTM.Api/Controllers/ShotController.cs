using System;
using System.Collections.Generic;
using System.Web.Http;
using WTM.Api.Models;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    [RoutePrefix("api/shot")]
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

        /// <summary>
        /// Find shot by ID
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns>Shot</returns>
        /// <response code="400">Invalid token</response>
        /// <response code="404">Shot not found</response>
        [Route("{id:int}")]
        public Shot GetById(int id, [FromBody]string token = null)
        {
            return new Shot();
        }

        /// <summary>
        /// Get random shot
        /// </summary>
        /// <param name="token">Session token</param>
        /// <returns>Shot</returns>
        /// <response code="400">Invalid token</response>
        [Route("random")]
        public Shot GetRandom([FromBody]string token = null)
        {
            return null;
        }

        /// <summary>
        /// Find shots by tag
        /// </summary>
        /// <param name="tags">Tags</param>
        /// <param name="token">Session token</param>
        /// <returns>Shot</returns>
        /// <response code="400">Invalid token</response>
        [Route("findByTag")]
        [HttpGet]
        public IEnumerable<ShotOverview> FindByTag(List<string> tags, int? start = null, int? limit = null, [FromBody]string token = null)
        {
            return null;
        }

        /// <summary>
        /// Find shots by date
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="token">Session token</param>
        /// <returns>Shot</returns>
        /// <response code="400">Invalid token</response>
        [Route("findByDate")]
        [HttpGet]
        public IEnumerable<ShotOverview> FindByDate(DateTime date, int? start = null, int? limit = null, [FromBody]string token = null)
        {
            return null;
        }

        /// <summary>
        /// Return shots older than 30 days
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="start">Start element</param>
        /// <param name="limit">Max number of element</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("archive")]
        [HttpGet]
        public IEnumerable<ShotOverview> Archive([FromBody]DateTime? date = null, [FromBody]int? start = null, [FromBody]int? limit = null, [FromBody]string token = null)
        {
            return null;
        }

        /// <summary>
        /// Return shot old less than 30 days
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="start">Start element</param>
        /// <param name="limit">Max number of element</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("featureFilms")]
        [HttpGet]
        public IEnumerable<ShotOverview> FeatureFilm([FromBody]DateTime? date = null, [FromBody]int? start = null, [FromBody]int? limit = null, [FromBody]string token = null)
        {
            return null;
        }

        /// <summary>
        /// Return new shots
        /// </summary>
        /// <param name="start">Start element</param>
        /// <param name="limit">Max number of element</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("newSubmissions")]
        [HttpGet]
        public IEnumerable<ShotOverview> NewSubmissions([FromBody]int? start = null, int? limit = null, [FromBody]string token = null)
        {
            return null;
        }

        /// <summary>
        /// Guess shot title
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="title">Guess title</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/guess")]
        public ShotGuessTitleResponse GuessSolution(int id, [FromBody]string title, [FromBody]string token = null)
        {
            return DoWork(() =>
            {
                var response = new ShotGuessTitleResponse();

                var guessTitleResponse = shotService.GuessTitle(id, title, token);

                if (guessTitleResponse != null)
                {
                    response.GuessTitleResponse = guessTitleResponse;
                }
                else
                {
                    response.AddError(new Error
                    {
                        Message = "Error occured on the server-side API"
                    });
                }

                return response;
            });
        }

        /// <summary>
        /// Get the solution (if it is available)
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/solution")]
        public ShotGuessTitleResponse GetSolution(int id, [FromBody]string token = null)
        {
            return DoWork(() =>
            {
                var response = new ShotGuessTitleResponse();

                var guessTitleResponse = shotService.GetSolution(id, token);

                if (guessTitleResponse != null)
                {
                    response.GuessTitleResponse = guessTitleResponse;
                }
                else
                {
                    response.AddError(new Error
                    {
                        Message = "Error occured on the server-side API"
                    });
                }

                return response;
            });
        }

        /// <summary>
        /// Rate shot
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="rate">Rate</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/rate")]
        public ShotRateResponse Rate(int id, [FromBody]int rate, [FromBody]string token = null)
        {
            return DoWork(() =>
            {
                var response = new ShotRateResponse();

                var rateResponse = shotService.Rate(id, rate, token);

                if (rateResponse != null)
                {
                    response.Rate = rateResponse;
                }
                else
                {
                    response.AddError(new Error
                    {
                        Message = "Error occured on the server-side API"
                    });
                }

                return response;
            });
        }

        /// <summary>
        /// Add shot to favourite
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/favourite")]
        public bool AddFavourite(int id, [FromBody]string token)
        {
            return false;
        }

        /// <summary>
        /// Delete shot from favorite
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/favourite")]
        [HttpDelete]
        public bool DeleteFavourite(int id, [FromBody]string token)
        {
            return false;
        }

        /// <summary>
        /// Add shot to bookmark
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/bookmark")]
        public bool AddBookmark(int id, [FromBody]string token)
        {
            return false;
        }

        /// <summary>
        /// Delete shot from bookmark
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/bookmark")]
        [HttpDelete]
        public bool DeleteBookmark(int id, [FromBody]string token)
        {
            return false;
        }

        /// <summary>
        /// Add tag to shot
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="tag">Tag</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/tag")]
        public bool AddTag(int id, [FromBody]string tag, [FromBody]string token)
        {
            return false;
        }

        /// <summary>
        /// Delete tage from shot
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="tag">Tag</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/tag")]
        [HttpDelete]
        public bool DeleteTag(int id, [FromBody]string tag, [FromBody]string token)
        {
            return false;
        }

    }

    public class ShotOverview
    {
    }
}