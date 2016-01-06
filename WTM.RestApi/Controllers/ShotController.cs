using System;
using System.Collections.Generic;
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

        #region Shots

        /// <summary>
        /// Get shot by ID
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

        /// <summary>
        /// Get shots by date
        /// </summary>
        /// <returns>Shots overview</returns>
        [Route("date")]
        [HttpGet]
        [ResponseType(typeof(IShotByDateResponse))]
        public IHttpActionResult GetByDate([FromUri]ShotByDateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotByDateResponse result;
            try
            {
                result = this.shotOverviewService.GetByDate(request.Date, request.Start, request.Limit, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get shots by tags
        /// </summary>
        /// <returns>Shot</returns>
        [Route("tag")]
        [HttpGet]
        [ResponseType(typeof(IShotSearchTagResponse))]
        public IHttpActionResult GetByTag([FromUri]ShotSearchTagRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
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
        /// Get shots by movie
        /// </summary>
        /// <returns></returns>
        [Route("movie")]
        [HttpGet]
        [ResponseType(typeof(IShotSearchMovieResponse))]
        public IHttpActionResult GetByMovie([FromUri]ShotSearchMovieRequest request)
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
        /// Get shots older than 30 days
        /// </summary>
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
        /// <returns></returns>
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
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/solution")]
        [ResponseType(typeof(ShotSolutionResponse))]
        public IHttpActionResult GetSolution(int id, [FromUri]string token)
        {
            ShotSolutionResponse result;
            try
            {
                result = this.shotService.GetSolution(id, token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        #endregion

        #region Rate

        /// <summary>
        /// Rate shot
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <returns></returns>
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/rate")]
        [HttpPost]
        [ResponseType(typeof(ShotRateResponse))]
        public IHttpActionResult Rate(int id, [FromBody]RateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShotRateResponse result;
            try
            {
                result = this.shotRateService.Rate(id, request.Rate, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        #endregion

        #region Favourites

        /// <summary>
        /// Get shot favourites
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/favourites")]
        [HttpPost]
        [ResponseType(typeof(ShotFavouritesResponse))]
        public IHttpActionResult GetFavourites([FromBody]FavouritesGetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShotFavouritesResponse result;
            try
            {
                result = this.shotFavouriteService.Get(request.Token, request.Start, request.Limit);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Add shot to favourite
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        [Route("{id:int}/favourites")]
        [HttpPost]
        [ResponseType(typeof(ShotFavouritesAddResponse))]
        public IHttpActionResult AddFavourite(int id, [FromBody]FavouritesAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShotFavouritesAddResponse result;
            try
            {
                result = this.shotFavouriteService.Add(id, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete shot from favorite
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/favourites")]
        [HttpDelete]
        [ResponseType(typeof(ShotFavouritesDeleteResponse))]
        public IHttpActionResult DeleteFavourite(int id, [FromBody]FavouritesDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShotFavouritesDeleteResponse result;
            try
            {
                result = this.shotFavouriteService.Delete(id, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        #endregion

        #region Bookmarks

        /// <summary>
        /// Get shot bookmarks
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/bookmarks")]
        [HttpGet]
        [ResponseType(typeof(ShotBookmarkResponse))]
        public IHttpActionResult GetBookmarks([FromBody]BookmarksGetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShotBookmarkResponse result;
            try
            {
                result = this.shotBookmarkService.Get(request.Token, request.Start, request.Limit);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Add shot to bookmark
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/bookmarks")]
        [HttpPost]
        [ResponseType(typeof(ShotBookmarkAddResponse))]
        public IHttpActionResult AddBookmarks(int id, [FromBody]BookmarksAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShotBookmarkAddResponse result;
            try
            {
                result = this.shotBookmarkService.Add(id, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete shot from bookmark
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/bookmarks")]
        [HttpDelete]
        [ResponseType(typeof(ShotBookmarkDeleteResponse))]
        public IHttpActionResult DeleteBookmark(int id, [FromBody]BookmarksDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShotBookmarkDeleteResponse result;
            try
            {
                result = this.shotBookmarkService.Delete(id, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        #endregion

        #region Tags

        /// <summary>
        /// Add tag to shot
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/tags")]
        [ResponseType(typeof(ShotTagAddResponse))]
        public IHttpActionResult AddTag(int id, [FromBody]TagsAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShotTagAddResponse result;
            try
            {
                result = this.shotTagService.Add(request.Tag, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
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
        [ResponseType(typeof(ShotTagDeleteResponse))]
        public IHttpActionResult DeleteTag(int id, [FromBody]TagsAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShotTagDeleteResponse result;
            try
            {
                result = this.shotTagService.Delete(request.Tag, request.Token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        #endregion
    }
}