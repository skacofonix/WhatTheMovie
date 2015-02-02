using System;

namespace WTM.WebsiteClient.Application
{
    public class ServerDateTime : IServerDateTime
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}