using System;

namespace WTM.CorePCL.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MandatoryAttribute : Attribute
    {
        public bool Mandatory { get; private set; }

        public MandatoryAttribute(bool mandatory = true)
        {
            Mandatory = mandatory;
        }
    }
}