using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class ShotController : ApiController
    {
        private ShotService shotService;

        public ShotController()
        {
            shotService = new ShotService();
        }

        // GET: api/Shot
        public Shot Get()
        {
            return shotService.GetRandomShot();
        }

        // GET: api/Shot/5
        public Shot Get(int id)
        {
            return "value";
        }
    }
}
