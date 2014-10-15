using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WTM.Core.Application.Attributes
{
    public class HtmlParserAttribute : Attribute
    {
        public string Pattern
        {
            get
            {
                if (regex != null)
                    regex.ToString();
                return null;
            }
            set
            {
                regex = new Regex(value);
            }
        }
        private Regex regex;

        public string XPathExpression { get; set; }

        public string jQuery { get; set; }
    }
}
