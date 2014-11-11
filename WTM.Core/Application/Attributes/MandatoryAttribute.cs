using System;

namespace WTM.Core.Application.Attributes
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