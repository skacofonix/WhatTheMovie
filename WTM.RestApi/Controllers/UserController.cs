using System.Web.Http;
using WTM.Crawler;
using WTM.RestApi.Models;
using WTM.RestApi.Models.Request;
using WTM.RestApi.Models.Response;

namespace WTM.RestApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController()
        {
            this.userService = new UserService(new Crawler.Services.UserService(new WebClientWTM(), new HtmlParser()));
        }

        [Route("login")]
        public LoginResponse Login([FromBody]LoginRequest request)
        {
            var token = this.userService.Login(request.Username, request.Password);

            var loginResponse = new LoginResponse();
            loginResponse.Data.Token = token;

            return loginResponse;
        }

        [Route("logout")]
        public LogoutResponse LogOut([FromBody] string token)
        {
            this.userService.Logout(token);

            var logoutResponse = new LogoutResponse();

            return logoutResponse;
        }
    }
}
