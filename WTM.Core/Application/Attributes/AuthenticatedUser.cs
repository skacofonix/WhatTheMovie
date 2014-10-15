using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Core.Application.Attributes
{
    public class AuthenticatedUser : Attribute
    {
        public bool Authenticated { get; set; }

        public bool SupporterUser { get; set; }

        public AuthenticatedUser(bool supporterUser = false)
        {
            Authenticated = true;
            SupporterUser = supporterUser;
        }
    }
}