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

            var filterGoreTrueTag = navigator.Select("//input[@id='user_prefers_filter_gore_true']");
            var blop = filterGoreTrueTag.MoveNext();
            var blip = filterGoreTrueTag.Current;

            var filterGoreFalseTag = navigator.SelectSingleNode("//input[@id='user_prefers_filter_gore_false']");
        }
    }
}
