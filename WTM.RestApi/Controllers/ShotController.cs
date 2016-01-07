using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
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
        private readonly IShotSummaryService shotSummaryService;
        private readonly IShoteRateService shotRateService;
        private readonly IShotFavouriteService shotFavouriteService;
        private readonly IShotBookmarkService shotBookmarkService;
        private readonly IShotTagService shotTagService;
        private readonly IMovieService movieService;

        public ShotController(IShotService shotService, IShotSummaryService shotSummaryService, IShoteRateService shotRateService, IShotFavouriteService shotFavouriteService, IShotBookmarkService shotBookmarkService, IShotTagService shotTagService, IMovieService movieService)
        {
            this.shotService = shotService;
            this.shotSummaryService = shotSummaryService;
            this.shotRateService = shotRateService;
            this.shotFavouriteService = shotFavouriteService;
            this.shotBookmarkService = shotBookmarkService;
            this.shotTagService = shotTagService;
            this.movieService = movieService;
        }

        /// <summary>
        /// Get shot by ID
        /// </summary>
        /// <returns>Shot</returns>
        /// <response code="404">Shot not found</response>
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(IShotResponse))]
        public IHttpActionResult Get(int id, [FromUri]ShotRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotResponse response;

            try
            {
                response = this.shotService.GetById(id, request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            if (response.Id != id)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Get random shot
        /// </summary>
        /// <returns>Shot</returns>
        [Route("random")]
        [HttpGet]
        [ResponseType(typeof(IShotResponse))]
        public IHttpActionResult GetRandom([FromUri]ShotRandomRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotResponse response;

            try
            {
                response = this.shotService.GetRandom(request);
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
                result = this.shotSummaryService.GetByDate(request);
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
        [Route("searchbytags")]
        [HttpGet]
        [ResponseType(typeof(IShotSearchTagResponse))]
        public IHttpActionResult GetByTag([FromUri]ShotSearchTagRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotSearchTagResponse response;
            try
            {
                response = this.shotSummaryService.SearchByTag(request);
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
        [Route("searchbymovie")]
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
                result = this.movieService.GetShotByMovie(request);
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
                result = this.shotSummaryService.GetArchives(request);
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
        [Route("featuresilms")]
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
                result = this.shotSummaryService.GetFeatureFilms(request);
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
        [Route("newsubmissions")]
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
                result = this.shotSummaryService.GetNewSubmissions(request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Guess shot title
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/guess")]
        [ResponseType(typeof(IShotGuessTitleResponse))]
        public IHttpActionResult GuessTitle(int id, [FromBody]GuessSolutionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotGuessTitleResponse result;

            try
            {
                result = this.shotService.GuessTitle(id, request);
            }
            catch (WebException wex)
            {
                var response = wex.Response as HttpWebResponse;
                if (response?.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound();
                }

                return InternalServerError(wex);
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
        [ResponseType(typeof(IShotSolutionResponse))]
        public IHttpActionResult GetSolution(int id, [FromUri]ShotSolutionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotSolutionResponse result;

            try
            {
                result = this.shotService.GetSolution(id, request);
            }
            catch (WebException wex)
            {
                var response = wex.Response as HttpWebResponse;
                if (response?.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound();
                }

                return InternalServerError(wex);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Rate shot
        /// </summary>
        /// <returns></returns>s
        /// <response code="400">Invalid token</response>
        [Route("{id:int}/rate")]
        [HttpPost]
        [ResponseType(typeof(IShotRateResponse))]
        public IHttpActionResult Rate(int id, [FromBody]RateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotRateResponse result;

            try
            {
                result = this.shotRateService.Rate(request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get shot favourites
        /// </summary>
        /// <returns></returns>
        [Route("favourites")]
        [HttpPost]
        [ResponseType(typeof(IShotFavouritesResponse))]
        public IHttpActionResult GetFavourites([FromBody]FavouritesGetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotFavouritesResponse result;

            try
            {
                result = this.shotFavouriteService.Get(request);
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
        /// <returns></returns>
        [Route("{id:int}/favourites")]
        [HttpPost]
        [ResponseType(typeof(IShotFavouritesAddResponse))]
        public IHttpActionResult AddFavourite(int id, [FromBody]FavouritesAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotFavouritesAddResponse result;

            try
            {
                result = this.shotFavouriteService.Add(id, request);
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
        [ResponseType(typeof(IShotFavouritesDeleteResponse))]
        public IHttpActionResult DeleteFavourite(int id, [FromBody]FavouritesDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotFavouritesDeleteResponse result;

            try
            {
                result = this.shotFavouriteService.Delete(id, request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get shot bookmarks
        /// </summary>
        /// <returns></returns>
        [Route("bookmarks")]
        [HttpGet]
        [ResponseType(typeof(IShotBookmarkResponse))]
        public IHttpActionResult GetBookmarks([FromBody]BookmarksGetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotBookmarkResponse result;

            try
            {
                result = this.shotBookmarkService.Get(request);
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
        [ResponseType(typeof(IShotBookmarkAddResponse))]
        public IHttpActionResult AddBookmarks(int id, [FromBody]BookmarksAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotBookmarkAddResponse result;

            try
            {
                result = this.shotBookmarkService.Add(id, request);
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
        [ResponseType(typeof(IShotBookmarkDeleteResponse))]
        public IHttpActionResult DeleteBookmark(int id, [FromBody]BookmarksDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotBookmarkDeleteResponse result;

            try
            {
                result = this.shotBookmarkService.Delete(id, request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Add tag to shot
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/tags")]
        [ResponseType(typeof(IShotTagAddResponse))]
        public IHttpActionResult AddTag(int id, [FromBody]TagsAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotTagAddResponse result;

            try
            {
                result = this.shotTagService.Add(id, request);
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
        /// <returns></returns>
        [Route("{id:int}/tags")]
        [HttpDelete]
        [ResponseType(typeof(IShotTagDeleteResponse))]
        public IHttpActionResult DeleteTag(int id, [FromBody]TagsDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotTagDeleteResponse result;

            try
            {
                result = this.shotTagService.Delete(id, request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }
    }
}