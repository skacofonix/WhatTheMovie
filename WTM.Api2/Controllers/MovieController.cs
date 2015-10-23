using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WTM.Api2.Models.Response;

namespace WTM.Api2.Controllers
{
    [RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        public MovieResponse GetByName([FromUri] string name)
        {
            return null;
        }

        [Route("findByTag")]
        [HttpGet]
        public IEnumerable<MovieOverviewResponse> FindByTag(List<string> tags, int? start = null, int? limit = null, [FromBody]string token = null)
        {
            return null;
        }
    }
}
