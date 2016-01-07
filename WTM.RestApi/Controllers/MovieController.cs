using System;
using System.Web.Http;
using System.Web.Http.Description;
using WTM.RestApi.Models;

namespace WTM.RestApi.Controllers
{
    [RoutePrefix("api/movie")]
    public class MovieController : ControllerBase
    {
        [Route("{name}")]
        [HttpGet]
        [ResponseType(typeof(IMovieResponse))]
        public IHttpActionResult Get([FromUri]string name)
        {
            return InternalServerError(new NotImplementedException());
        }

        [Route("tag")]
        [HttpGet]
        [ResponseType(typeof(IMovieSearchTagResponse))]
        public IHttpActionResult GetByTag(MovieSearchTagRequest request)
        {
            return InternalServerError(new NotImplementedException());
        }
    }
}