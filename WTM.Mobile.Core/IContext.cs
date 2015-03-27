﻿using WTM.Domain;

namespace WTM.Mobile.Core
{
    public interface IContext
    {
        User CurrentUser { get; }

        string Token { get; }

        void SetUserContext(User user, string token);

        void ResetUserContext();
    }
}