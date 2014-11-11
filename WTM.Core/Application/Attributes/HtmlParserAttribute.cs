using System;

namespace WTM.Core.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class HtmlParserAttribute : Attribute
    {
        public string XPathExpression { get; private set; }

        public string RegexPattern { get; private set; }
      
        public bool PatternIsDefined 
        {
            get
            {
                return string.IsNullOrEmpty(RegexPattern);
            }
        }

        public HtmlParserAttribute(string xPathExpression, string regexPattern = null)
        {
            XPathExpression = xPathExpression;
            RegexPattern = regexPattern;
        }
    }
}