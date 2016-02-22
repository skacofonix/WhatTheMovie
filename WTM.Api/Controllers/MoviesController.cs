using System;
using System.Web.Http;
using System.Web.Http.Description;
using WTM.Api.Models;

namespace WTM.Api.Controllers
{
    [RoutePrefix("api/movie")]
    public class MoviesController : ControllerBase
    {
        [Route("{name}")]
        [HttpGet]
        [ResponseType(typeof(MovieResponse))]
        public IHttpActionResult Get([FromUri]string name)
        {
            return InternalServerError(new NotImplementedException());
        }

        [Route("tag")]
        [HttpGet]
        [ResponseType(typeof(MovieSearchTagResponse))]
        public IHttpActionResult GetByTag(MovieSearchTagRequest request)
        {
            return InternalServerError(new NotImplementedException());
        }
    }
}