using WTM.Api.Core;
using WTM.Domain;
using WTM.WebsiteClient.Application;

namespace WTM.WebsiteClient
{
    public interface IContext
    {
        User User { get; }

        IDisplayOptions DisplayOptions { get; }

        IWebClient WebClient { get; }

        IHtmlParser HtmlParser { get; }
    }
}