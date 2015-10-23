using System.Web.Http;
using WTM.RestApi.Models.Response;

namespace WTM.RestApi.Controllers
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
