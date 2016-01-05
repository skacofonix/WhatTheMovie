namespace WTM.RestApi.Models
{
    public class LoginResponse : ResponseBase<Login>
    {
        public LoginResponse()
        {
            this.Data = new Login();
        }
    }
}