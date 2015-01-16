using WTM.Core.Application;

namespace WTM.Core.Services
{
    internal class ShotNewSubmissionsService : ShotService
    {
        protected override string PageIdentifier { get { return "newsubmissions"; } }

        public ShotNewSubmissionsService(IWebClient webClient, IHtmlParser htmlParser) : base(webClient, htmlParser)
        {
        }
    }
}
