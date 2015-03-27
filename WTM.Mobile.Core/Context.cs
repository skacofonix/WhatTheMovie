using WTM.Domain;

namespace WTM.Mobile.Core
{
    public class Context : IContext
    {
        public User CurrentUser { get; private set; }

        public string Token { get; private set; }

        public void SetUserContext(User user, string token)
        {
            CurrentUser = user;
            Token = token;
        }

        public void ResetUserContext()
        {
            CurrentUser = null;
            Token = null;
        }
    }
}