namespace WTM.RestApi.Models
{
    public class LoginResponse : IResponse, IAuthenticable
    {
        public LoginResponse(string token)
        {
            this.Token = token;
        }

        public string Token { get; private set; }
    }
}