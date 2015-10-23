using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using WTM.Api2.Models.Response;
using WTM.Api2.Services;

namespace WTM.Api2.Controllers
{
    [RoutePrefix("api/shot")]
    public class ShotController : ApiController
    {
        private readonly IShotService shotService;
        private readonly IShotOverviewService shotOverviewService;
        private readonly IShoteRateService shotRateService;
        private readonly IShotFavouriteService shotFavouriteService;
        private readonly IShotBookmarkService shotBookmarkService;
        private readonly IShotTagService shotTagService;
        private readonly IMovieService movieService;

        public ShotController(IShotService shotService, IShotOverviewService shotOverviewService, IShoteRateService shotRateService, IShotFavouriteService shotFavouriteService, IShotBookmarkService shotBookmarkService, IShotTagService shotTagService, IMovieService movieService)
        {
            this.shotService = shotService;
            this.shotOverviewService = shotOverviewService;
            this.shotRateService = shotRateService;
            this.shotFavouriteService = shotFavouriteService;
            this.shotBookmarkService = shotBookmarkService;
            this.shotTagService = shotTagService;
            this.movieService = movieService;
        }

        #region Shot

        /// <summary>
        /// Find shot by ID
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns>Shot</returns>
        /// <response code="404">Shot not found</response>
        [Route("{id:int}")]
        public ShotResponse GetById(int id, [FromBody]string token = null)
        {
            return this.shotService.GetById(id, token);
        }

        /// <summary>
        /// Get random shot
        /// </summary>
        /// <param name="token">Session token</param>
        /// <returns>Shot</returns>
        [Route("random")]
        public ShotResponse GetRandom([FromBody]string token = null)
        {
            return this.shotService.GetRandom(token);
        }

        #endregion

        #region Shots

        /// <summary>
        /// Find shots by tag
        /// </summary>
        /// <param name="tags">Tags</param>
        /// <param name="token">Session token</param>
        /// <returns>Shot</returns>
        [Route("findByTag")]
        [HttpGet]
        public IEnumerable<ShotOverviewResponse> FindByTag(List<string> tags, int? start = null, int? limit = null, [FromBody]string token = null)
        {
            return this.shotOverviewService.FindByTag(tags, start, limit, token);
        }

        /// <summary>
        /// Find shots by date
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="token">Session token</param>
        /// <returns>Shots overview</returns>
        [Route("findByDate")]
        [HttpGet]
        public IEnumerable<ShotOverviewResponse> FindByDate(DateTime date, int? start = null, int? limit = null, [FromBody]string token = null)
        {
            return this.shotOverviewService.FindByDate(date, start, limit, token);
        }

        /// <summary>
        /// Find shots by movie
        /// </summary>
        /// <param name="name">Movie name</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("findByMovie")]
        [HttpGet]
        public IEnumerable<ShotOverviewResponse> FindByMovie([FromBody] string name, [FromBody] string token = null)
        {
            return this.movieService.GetShotByMovie(name, token);
        }

        /// <summary>
        /// Return shots older than 30 days
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="start">Start element</param>
        /// <param name="limit">Max number of element</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("archives")]
        [HttpGet]
        public IEnumerable<ShotOverviewResponse> GetArchives([FromBody]DateTime? date = null, [FromBody]int? start = null, [FromBody]int? limit = null, [FromBody]string token = null)
        {
            return this.shotOverviewService.GetArchives(date, start, limit, token);
        }

        /// <summary>
        /// Get shots old less than 30 days
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="start">Start element</param>
        /// <param name="limit">Max number of element</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("featureFilms")]
        [HttpGet]
        public IEnumerable<ShotOverviewResponse> GetFeatureFilms([FromBody]DateTime? date = null, [FromBody]int? start = null, [FromBody]int? limit = null, [FromBody]string token = null)
        {
            return this.shotOverviewService.GetFeatureFilms(date, start, limit, token);
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
        public IEnumerable<ShotOverviewResponse> GetNewSubmissions([FromBody]int? start = null, int? limit = null, [FromBody]string token = null)
        {
            return this.shotOverviewService.GetNewSubmissions(start, limit, token);
        }

        #endregion

        #region Solution

        /// <summary>
        /// Guess shot title
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="title">Guess title</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/guess")]
        public ShotGuessSolutionResponse GuessSolution(int id, [FromBody]string title, [FromBody]string token = null)
        {
            return this.shotService.GuessSolution(id, title, token);
        }

        /// <summary>
        /// Get the solution (if it is available)
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/solution")]
        public ShotSolutionResponse GetSolution(int id, [FromBody]string token = null)
        {
            return this.shotService.GetSolution(id, token);
        }

        #endregion

        #region Rate

        /// <summary>
        /// Rate shot
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="rate">Rate</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/rate")]
        public ShotRateResponse Rate(int id, [FromBody]int rate, [FromBody]string token)
        {
            return this.shotRateService.Rate(id, rate, token);
        }

        #endregion

        #region Favourites

        /// <summary>
        /// Add shot to favourite
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/favourites")]
        public bool AddFavourite(int id, [FromBody]string token)
        {
            return this.shotFavouriteService.Add(id, token);
        }

        /// <summary>
        /// Delete shot from favorite
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/favourites")]
        [HttpDelete]
        public bool DeleteFavourite(int id, [FromBody]string token)
        {
            return this.shotFavouriteService.Delete(id, token);
        }

        /// <summary>
        /// Get shot favourites
        /// </summary>
        /// <param name="start">Start element</param>
        /// <param name="limit">Max number of element</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/favourites")]
        [HttpGet]
        public IEnumerable<ShotOverviewResponse> GetFavourites([FromBody] string token, [FromBody] int? start = null, [FromBody] int? limit = null)
        {
            return this.shotFavouriteService.Get(token, start, limit);
        }

        #endregion

        #region Bookmarks

        /// <summary>
        /// Add shot to bookmark
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/bookmarks")]
        public bool AddBookmark(int id, [FromBody]string token)
        {
            return this.shotBookmarkService.Add(id, token);
        }

        /// <summary>
        /// Delete shot from bookmark
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/bookmarks")]
        [HttpDelete]
        public bool DeleteBookmark(int id, [FromBody]string token)
        {
            return this.shotBookmarkService.Delete(id, token);
        }

        /// <summary>
        /// Get shot bookmarks
        /// </summary>
        /// <param name="start">Start element</param>
        /// <param name="limit">Max number of element</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/bookmarks")]
        [HttpGet]
        public IEnumerable<ShotOverviewResponse> GetBookmarks([FromBody] string token, [FromBody] int? start = null, [FromBody] int? limit = null)
        {
            return this.shotBookmarkService.Get(token, start, limit);
        }

        #endregion

        #region Tags

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
            return this.shotTagService.Add(tag, token);
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
            return this.shotTagService.Delete(tag, token);
        }

        #endregion
    }
}
