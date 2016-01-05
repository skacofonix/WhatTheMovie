using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WTM.RestApi.Models;
using WTM.RestApi.Services;

namespace WTM.RestApi.Controllers
{
    [RoutePrefix("api/shots")]
    public class ShotController : ControllerBase
    {
        private readonly IShotService shotService;
        private readonly IShotOverviewService shotOverviewService;
        private readonly IShoteRateService shotRateService;
        private readonly IShotFavouriteService shotFavouriteService;
        private readonly IShotBookmarkService shotBookmarkService;
        private readonly IShotTagService shotTagService;
        private readonly IMovieService movieService;

        public ShotController(IShotService shotService, IShotOverviewService shotOverviewService, IShoteRateService shotRateService, IShotFavouriteService shotFavouriteService, IShotBookmarkService shotBookmarkService, IShotTagService shotTagService, IMovieService movieService)
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement
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
        [HttpGet]
        [ResponseType(typeof(ShotResponse))]
        public IHttpActionResult Get(int id, [FromUri]string token = null)
        {
            ShotResponse response;

            try
            {
                response = this.shotService.GetById(id, token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(response);
        }

        /// <summary>
        /// Get random shot
        /// </summary>
        /// <param name="token">Session token</param>
        /// <returns>Shot</returns>
        [Route("random")]
        [HttpGet]
        [ResponseType(typeof(ShotResponse))]
        public IHttpActionResult GetRandom([FromUri]string token = null)
        {
            ShotResponse response;

            try
            {
                response = this.shotService.GetRandom(token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(response);
        }

        #endregion

        #region Shots

        /// <summary>
        /// Search shots by tag
        /// </summary>
        /// <param name="tags">Tags</param>
        /// <param name="token">Session token</param>
        /// <returns>Shot</returns>
        [Route("searchByTag")]
        [HttpGet]
        [ResponseType(typeof(IShotSearchTagResponse))]
        public IHttpActionResult SearchByTag([FromUri]ShotSearchTagRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotSearchTagResponse response;
            try
            {
                response = this.shotOverviewService.SearchByTag(request.Tags, request.Start, request.Limit, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(response);
        }

        /// <summary>
        /// Find shots by date
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="token">Session token</param>
        /// <returns>Shots overview</returns>
        [Route("findByDate")]
        [HttpGet]
        [ResponseType(typeof(IShotSearchDateResponse))]
        public IHttpActionResult FindByDate([FromUri]ShotSearchDateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotSearchDateResponse result;
            try
            {
                result = this.shotOverviewService.SearchByDate(request.Date, request.Start, request.Limit, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Find shots by movie
        /// </summary>
        /// <param name="name">Movie name</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("searchByMovie")]
        [HttpGet]
        [ResponseType(typeof(IShotSearchMovieResponse))]
        public IHttpActionResult FindByMovie([FromUri]ShotSearchMovieRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotSearchMovieResponse result;
            try
            {
                result = this.movieService.GetShotByMovie(request.Name, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
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
        [ResponseType(typeof(IShotArchivesResponse))]
        public IHttpActionResult GetArchives([FromUri]ShotArchivesRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotArchivesResponse result;
            try
            {
                result = this.shotOverviewService.GetArchives(request.Date, request.Start, request.Limit, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
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
        [ResponseType(typeof(IShotFeatureFilmsResponse))]
        public IHttpActionResult GetFeatureFilms([FromUri]ShotFeatureFilmsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotFeatureFilmsResponse result;
            try
            {
                result = this.shotOverviewService.GetFeatureFilms(request.Date, request.Start, request.Limit, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
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
        [ResponseType(typeof(IShotNewSubmissionsResponse))]
        public IHttpActionResult GetNewSubmissions([FromUri]ShotNewSubmissionsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotNewSubmissionsResponse result;
            try
            {
                result = this.shotOverviewService.GetNewSubmissions(request.Start, request.Limit, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        #endregion

        #region Solution

        /// <summary>
        /// Guess shot title
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="request">Request</param>
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/guess")]
        [ResponseType(typeof(IShotGuessSolution))]
        public IHttpActionResult GuessSolution(int id, [FromBody]GuessSolutionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotGuessSolution result;
            try
            {
                result = this.shotService.GuessSolution(id, request.Title, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get the solution (if it is available)
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/solution")]
        public ShotSolutionResponse GetSolution(int id, [FromUri]string token)
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
        public ShotRateResponse Rate(int id, [FromBody]RateRequest request)
        {
            return this.shotRateService.Rate(id, request.Rate, request.Token);
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
        public bool AddFavourite(int id, [FromBody]FavouritesAddRequest request)
        {
            return this.shotFavouriteService.Add(id, request.Token);
        }

        /// <summary>
        /// Delete shot from favorite
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/favourites")]
        [HttpDelete]
        public bool DeleteFavourite(int id, [FromBody]FavouritesDeleteRequest request)
        {
            return this.shotFavouriteService.Delete(id, request.Token);
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
        public IEnumerable<ShotOverviewResponse> GetFavourites([FromBody]FavouritesGetRequest request)
        {
            return this.shotFavouriteService.Get(request.Token, request.Start, request.Limit);
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
        public bool AddBookmarks(int id, [FromBody]BookmarksAddRequest request)
        {
            return this.shotBookmarkService.Add(id, request.Token);
        }

        /// <summary>
        /// Delete shot from bookmark
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/bookmarks")]
        [HttpDelete]
        public bool DeleteBookmark(int id, [FromBody]BookmarksDeleteRequest request)
        {
            return this.shotBookmarkService.Delete(id, request.Token);
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
        public IEnumerable<ShotOverviewResponse> GetBookmarks([FromBody]BookmarksGetRequest request)
        {
            return this.shotBookmarkService.GetBookmarks(request.Token, request.Start, request.Limit);
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
        [Route("{id:int}/tags")]
        public bool AddTag(int id, [FromBody]TagsAddRequest request)
        {
            return this.shotTagService.Add(request.Tag, request.Token);
        }

        /// <summary>
        /// Delete tage from shot
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="tag">Tag</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/tags")]
        [HttpDelete]
        public bool DeleteTag(int id, [FromBody]TagsAddRequest request)
        {
            return this.shotTagService.Delete(request.Tag, request.Token);
        }

        #endregion
    }
}