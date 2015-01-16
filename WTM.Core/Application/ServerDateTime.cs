using System;

namespace WTM.Core.Application
{
    public class ServerDateTime : IServerDateTime
    {
        public DateTime? GetDateTime()
        {
            return DateTime.Now;
        }
    }
}