using WTM.Api.Core;

namespace WTM.Domain
{
    public class DisplayOptions : IDisplayOptions
    {
        public bool ShowSolvedShot { get; private set; }
        public bool ShowUnsolvedShot { get; private set; }
        public bool ShowPostedShot { get; private set; }

        public bool FilterGore { get; private set; }
        public bool FilterNudity { get; private set; }
    }
}