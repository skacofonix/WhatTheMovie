using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security;
using WTM.Api2.Models.Response;

namespace WTM.Api2.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [Route("login")]
        [HttpPost]
        public LoginResponse Login([FromBody]string login, [FromBody]string password)
        {
            return null;
        }

        [Route("logout")]
        public LogoutResponse LogOut([FromBody] string token)
        {
            return null;
        }
    }
}
