namespace WTM.Domain.Response
{
    public class LoginResponse : ResponseBase<Login>
    {
        public LoginResponse()
        {
            this.Data = new Login();
        }
    }
}