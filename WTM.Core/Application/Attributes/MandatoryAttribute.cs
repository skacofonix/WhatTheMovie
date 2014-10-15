using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Core.Application.Attributes
{
    public class MandatoryAttribute : Attribute
    {
        public bool Mandatory { get; private set; }

        public MandatoryAttribute(bool mandatory = true)
        {
            Mandatory = mandatory;
        }
    }
}