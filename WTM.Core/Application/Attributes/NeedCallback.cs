using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Core.Application.Attributes
{
    public class NeedCallback : Attribute
    {
        public string Url { get; set; }
        public string Param { get; set; }
    }
}
