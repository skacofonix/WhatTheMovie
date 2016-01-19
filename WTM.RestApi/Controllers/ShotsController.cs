using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Services.Description;
using WTM.RestApi.Models;
using WTM.RestApi.Services;

namespace WTM.RestApi.Controllers
{
    [RoutePrefix("api/shots")]
    public class ShotsController : ControllerBase
    {
        private readonly IShotService shotService;
        private readonly IShotSummaryService shotSummaryService;
        private readonly IShoteRateService shotRateService;
        private readonly IShotFavouriteService shotFavouriteService;
        private readonly IShotBookmarkService shotBookmarkService;
        private readonly IShotTagService shotTagService;
        private readonly IMovieService movieService;
        private readonly IImageResourceService imageResourceService;

        public ShotsController(IShotService shotService, IShotSummaryService shotSummaryService, IShoteRateService shotRateService, IShotFavouriteService shotFavouriteService, IShotBookmarkService shotBookmarkService, IShotTagService shotTagService, IMovieService movieService, IImageResourceService imageResourceService)
        {
            this.shotService = shotService;
            this.shotSummaryService = shotSummaryService;
            this.shotRateService = shotRateService;
            this.shotFavouriteService = shotFavouriteService;
            this.shotBookmarkService = shotBookmarkService;
            this.shotTagService = shotTagService;
            this.movieService = movieService;
            this.imageResourceService = imageResourceService;
        }

        /// <summary>
        /// Get shots
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(ShotCollectionResponse))]
        public IHttpActionResult Get([FromUri]ShotsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotCollectionResponse result;
            try
            {
                result = this.shotSummaryService.Get(request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get random shot
        /// </summary>
        /// <returns>Shot</returns>
        [Route("random")]
        [HttpGet]
        [ResponseType(typeof(ShotResponse))]
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
        /// Get shots older than 30 days
        /// </summary>
        /// <returns></returns>
        [Route("archives")]
        [HttpGet]
        [ResponseType(typeof(ShotCollectionResponse))]
        public IHttpActionResult GetArchives([FromUri]ShotArchivesRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotCollectionResponse result;
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
        [Route("featuresfilms")]
        [HttpGet]
        [ResponseType(typeof(ShotCollectionResponse))]
        public IHttpActionResult GetFeatureFilms([FromUri]ShotFeatureFilmsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotCollectionResponse result;
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
        [ResponseType(typeof(ShotCollectionResponse))]
        public IHttpActionResult GetNewSubmissions([FromUri]ShotNewSubmissionsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IShotCollectionResponse result;
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
        /// Get shot by ID
        /// </summary>
        /// <returns>Shot</returns>
        /// <response code="404">Shot not found</response>
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(ShotResponse))]
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
        /// Guess shot title
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/guess")]
        [ResponseType(typeof(ShotGuessTitleResponse))]
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
        [ResponseType(typeof(ShotSolutionResponse))]
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
        /// Get shot thumbnail by ID
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <returns>Thumbnail</returns>
        [Route("{id:int}/thumb")]
        [HttpGet]
        public HttpResponseMessage GetThumbnail(int id)
        {
            HttpResponseMessage response;

            try
            {
                var rawData = this.imageResourceService.GetThumbnail(id);
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(rawData);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            }
            catch (NotFoundException nfe)
            {
                response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return response;
        }

        /// <summary>
        /// Get shot image by ID
        /// </summary>
        /// <param name="id">Shot ID</param>
        /// <returns>Image</returns>
        [Route("{id:int}/image")]
        [HttpGet]
        public HttpResponseMessage GetImage(int id)
        {
            HttpResponseMessage response;

            try
            {
                var rawData = this.imageResourceService.GetImage(id);
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(rawData);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            }
            catch (NotFoundException nfe)
            {
                response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return response;
        }

        /// <summary>
        /// Get shots by tag
        /// </summary>
        /// <returns>Shot</returns>
        [Route("search")]
        [HttpGet]
        [ResponseType(typeof(ShotResponse))]
        public IHttpActionResult Search([FromUri]ShotSearchRequest request)
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

        /*

        /// <summary>
        /// Rate shot
        /// </summary>
        /// <returns></returns>s
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
        [ResponseType(typeof(ShotFavouritesResponse))]
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
        [ResponseType(typeof(ShotFavouritesAddResponse))]
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
        [ResponseType(typeof(ShotFavouritesDeleteResponse))]
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
        [ResponseType(typeof(ShotBookmarkResponse))]
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
        [ResponseType(typeof(ShotBookmarkAddResponse))]
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
        [ResponseType(typeof(ShotBookmarkDeleteResponse))]
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
        [ResponseType(typeof(ShotTagAddResponse))]
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
        [ResponseType(typeof(ShotTagDeleteResponse))]
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

        */
    }
}