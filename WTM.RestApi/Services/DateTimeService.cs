using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
