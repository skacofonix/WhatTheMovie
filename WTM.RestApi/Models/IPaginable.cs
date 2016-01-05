using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WTM.RestApi.Models
{
    public interface IPaginable
    {
        int? Start { get; }

        int? Limit { get; }
    } 
}