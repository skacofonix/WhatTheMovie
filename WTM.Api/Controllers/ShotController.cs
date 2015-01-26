using System.Web.Http;
using WTM.Core;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class ShotController : ApiController
    {
        private readonly ShotService shotService;

        public ShotController()
        {
            var context = new Context();
            shotService = new ShotService(context);
        }

        // GET: api/Shot
        public Shot Get()
        {
            return shotService.GetRandomShot();
        }

        // GET: api/Shot/5
        public Shot Get(int id)
        {
            return shotService.GetShotById(id);
        }

        // GET: api/Random
        public Shot Random()
        {
            return shotService.GetRandomShot();
        }
    }
}
