using System;
using WTM.Domain;

namespace WTM.Mobile.Core
{
    public class UserEvent : EventArgs
    {
        public UserEvent(User user)
        {
            User = user;
        }

        public User User { get; private set; }
    }
}