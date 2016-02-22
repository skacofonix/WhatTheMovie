using System;

namespace WTM.Api.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetDateTime()
        {
            return System.DateTime.Now;
        }
    }
}
