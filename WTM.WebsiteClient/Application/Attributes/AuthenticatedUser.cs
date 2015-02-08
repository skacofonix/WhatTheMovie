﻿using System;

namespace WTM.WebsiteClient.Application.Attributes
{
    public class AuthenticatedUser : Attribute
    {
        public bool Authenticated { get; private set; }

        public bool SupporterUser { get; private set; }

        public AuthenticatedUser(bool supporterUser = false)
        {
            Authenticated = true;
            SupporterUser = supporterUser;
        }
    }
}