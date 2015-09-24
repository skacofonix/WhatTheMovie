using System.Web.Http;
using System;

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
