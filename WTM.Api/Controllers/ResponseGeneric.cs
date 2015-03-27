using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Api.Domain;

namespace WTM.Api.Controllers
{
    public class ResponseGeneric<T> where T : IResponse
    {
    }
}
