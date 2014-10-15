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
        public string jQuery { get; set; }

        public string Pattern { get; set; }
      
        public bool PatternIsDefined 
        {
            get
            {
                return string.IsNullOrEmpty(Pattern); ;
            }
        }

        public HtmlParserAttribute(string jQuerySelector, string regexPattern = null)
        {
            jQuery = jQuery = jQuerySelector;
            Pattern = regexPattern;
        }
    }
}