using System;
using WTM.Core.Application;

namespace WTM.Core.Services
{
    internal class ShotArchiveService : ShotService
    {
        protected override string PageIdentifier { get { return "overview"; } }

        public ShotArchiveService(IWebClient webClient, IHtmlParser htmlParser) : base(webClient, htmlParser)
        {
        }
    }
}
