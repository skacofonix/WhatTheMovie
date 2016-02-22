﻿using WTM.Api.Models;

namespace WTM.Api.Services
{
    public interface IUserService
    {
        IUserResponse Get(string username);

        IUserLoginResponse Login(UserLoginRequest request);

        IUserLogoutResponse Logout(UserLogoutRequest request);

        IUserSearchResponse Search(IUserSearchRequest request);

        IUserSummary GetUserSummaryByToken(string token);
    }
}