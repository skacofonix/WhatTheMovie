using WTM.Api.Core;
using WTM.Domain;
using WTM.WebsiteClient.Application;

namespace WTM.WebsiteClient
{
    public class Context : IContext
    {
        public User User { get; set; }
        public IDisplayOptions DisplayOptions { get; private set; }
        public IWebClient WebClient { get; private set; }
        public IHtmlParser HtmlParser { get; private set; }

        public Context()
        {
            HtmlParser = new HtmlParser();
            WebClient = new WebClientWTM();
            DisplayOptions = new DisplayOptions();
            User = null;
        }
    }
}