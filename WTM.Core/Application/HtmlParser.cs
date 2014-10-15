using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Core.Application
{
    public class HtmlParser
    {
        public HtmlDocument GetHtmlDocument(Stream stream)
        {
            return LoadHtmlDocument(stream);
        }

        private HtmlDocument LoadHtmlDocument(Stream stream)
        {
            var document = new HtmlDocument();
            document.Load(stream);
            return document;
        }
    }
}