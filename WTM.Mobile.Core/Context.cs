using System;
using WTM.Domain;
using WTM.Domain.OldSchool;

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
            FireUserChange(user);
        }

        public void ResetUserContext()
        {
            CurrentUser = null;
            Token = null;
            FireUserChange(null);
        }

        private void FireUserChange(User user)
        {
            if (OnUserChange != null)
            {
                OnUserChange(this, new UserEvent(user));
            }
        }

        public event EventHandler<UserEvent> OnUserChange;
    }
}