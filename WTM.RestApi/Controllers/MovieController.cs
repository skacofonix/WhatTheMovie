using System.Collections.Generic;
using System.Web.Http;
using WTM.Domain.Response;

namespace WTM.RestApi.Controllers
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
        public IEnumerable<MovieOverviewResponse> FindByTag(List<string> tags, int? start = null, int? limit = null, string token = null)
        {
            return null;
        }
    }
}
