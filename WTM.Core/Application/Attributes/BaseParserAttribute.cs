using System;

namespace WTM.Core.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class BaseParserAttribute : Attribute
    {
        public string XPathExpression { get; private set; }

        public string RegexPattern { get; private set; }

        protected BaseParserAttribute(string xPathExpression, string regexPattern = null)
        {
            XPathExpression = xPathExpression;
            RegexPattern = regexPattern;
        }
    }
}
