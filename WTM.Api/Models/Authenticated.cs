namespace WTM.Api.Models
{
    public class Authenticated : IAuthenticated
    {
        public Authenticated(IUserSummary user)
        {
            IsAuthenticated = true;
            User = user;
        }

        public bool IsAuthenticated { get; private set; }

        public IUserSummary User { get; private set; }
    }
}