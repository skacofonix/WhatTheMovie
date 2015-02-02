using WTM.Domain;
using WTM.WebsiteClient.Application;

namespace WTM.Api.Core
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