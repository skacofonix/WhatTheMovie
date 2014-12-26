using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Core.Application
{
    public class AppSettings : IAppSettings
    {
        public string Proxy { get; set; }

        public string UserAgent { get; set; }
    }
}
