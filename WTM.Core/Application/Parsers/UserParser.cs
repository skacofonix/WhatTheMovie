using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Parsers
{
    internal class UserParser : ParserBase<User>
    {
        public override string Identifier { get { return "user"; } }

        public UserParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }
    }
}
