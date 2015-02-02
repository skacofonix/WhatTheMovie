using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Domain;
using WTM.WebsiteClient.Application;

namespace WTM.Api.Core
{
    public interface IContext
    {
        User User { get; }

        IDisplayOptions DisplayOptions { get; }

        IWebClient WebClient { get; }

        IHtmlParser HtmlParser { get; }
    }
}
