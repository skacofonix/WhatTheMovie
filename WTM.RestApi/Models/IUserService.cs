using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.RestApi.Models
{
    interface IUserService
    {
        string Login(string username, string password);

        void Logout(string token);
    }
}