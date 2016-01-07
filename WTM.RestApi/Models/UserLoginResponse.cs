namespace WTM.RestApi.Models
{
    public class UserLoginResponse : IUserLoginResponse
    {
        public UserLoginResponse(string token)
        {
            this.Token = token;
        }

        public string Token { get; private set; }
    }
}