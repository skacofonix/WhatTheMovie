using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WTM.Api.Controllers
{
    public class StatusController : ApiController
    {
        // GET api/Status/Ping
        public string Ping()
        {
            return "Pong";
        }

        public DateTime GetApiDateTime()
        {
            return DateTime.Now;
        }

        public DateTime GetWtmDateTime()
        {
            throw new NotImplementedException();
        }

        //public string GetMessageOfTheDay
    }
}
