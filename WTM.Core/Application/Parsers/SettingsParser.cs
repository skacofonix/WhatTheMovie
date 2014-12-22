using System.Text.RegularExpressions;
using HtmlAgilityPack;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Parsers
{
    internal class SettingsParser : ParserBase<Settings>
    {
        public override string Identifier { get { return "user/settings"; } }

        public SettingsParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public Settings Parse()
        {
            return this.Parse(null);
        }

        protected override void Parse(Settings instance, HtmlDocument htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null) return;
            
            const string trueHtmlInputValue ="value=\"(true|false)\"";

            var showGore = false;
            var filterGoreTrueTag = navigator.SelectSingleNode("//input[@id='user_prefers_filter_gore_true']");
            if (filterGoreTrueTag != null && Regex.IsMatch(filterGoreTrueTag.OuterXml, trueHtmlInputValue))
                showGore = true;
            instance.ShowGore = showGore;

            var showNudity = false;
            var filterNudityTrueTag = navigator.SelectSingleNode("//input[@id='user_prefers_filter_nudity_true']");
            if (filterNudityTrueTag != null && Regex.IsMatch(filterNudityTrueTag.OuterXml, trueHtmlInputValue))
                showNudity = true;
            instance.ShowNudity = showNudity;
        }
    }
}
