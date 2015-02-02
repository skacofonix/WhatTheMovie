using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Domain;

namespace WTM.Api.Core.Services
{
    interface IContextService
    {
        User Login(string username, string password);

        bool Logout();
    }
}
