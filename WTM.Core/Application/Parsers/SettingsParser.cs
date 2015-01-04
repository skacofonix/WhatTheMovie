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
            return base.Parse(null);
        }

        public Settings Parse(HtmlDocument htmlDocument)
        {
            var settings = new Settings();
            Parse(settings, htmlDocument);
            return settings;
        }

        protected override void Parse(Settings instance, HtmlDocument htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null) return;
            
            const string checkedHtmlValue = "checked=\"checked\"";

            var filterGoreTrueTag = navigator.SelectSingleNode("//input[@id='user_prefers_filter_gore_true']");
            if (filterGoreTrueTag != null && Regex.IsMatch(filterGoreTrueTag.OuterXml, checkedHtmlValue))
            {
                instance.ShowGore = false;
            }
            else
            {
                var filterGoreFalseTag = navigator.SelectSingleNode("//input[@id='user_prefers_filter_gore_false']");
                if (filterGoreFalseTag != null && Regex.IsMatch(filterGoreFalseTag.OuterXml, checkedHtmlValue))
                    instance.ShowGore = true;
            }

            var filterNudityTrueTag = navigator.SelectSingleNode("//input[@id='user_prefers_filter_nudity_true']");
            if (filterNudityTrueTag != null && Regex.IsMatch(filterNudityTrueTag.OuterXml, checkedHtmlValue))
            {
                instance.ShowNudity = false;
            }
            else
            {
                var filterNudityFalseTag = navigator.SelectSingleNode("//input[@id='user_prefers_filter_nudity_false']");
                if (filterNudityFalseTag != null && Regex.IsMatch(filterNudityFalseTag.OuterXml, checkedHtmlValue))
                    instance.ShowNudity = true;
            }
        }
    }
}
