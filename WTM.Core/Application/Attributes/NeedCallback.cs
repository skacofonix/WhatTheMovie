using System;

namespace WTM.Core.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NeedCallback : Attribute
    {
        public string Url { get; private set; }
        public string Param { get; private set; }

        public NeedCallback(string url, string param)
        {
            Url = url;
            Param = param;
        }
    }
}