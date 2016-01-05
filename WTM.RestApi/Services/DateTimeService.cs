using System;

namespace WTM.RestApi.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetDateTime()
        {
            return System.DateTime.Now;
        }
    }
}
