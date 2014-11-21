using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Core
{
    class OverviewDisplayOption
    {
        public bool ShowSolved { get; private set; }
        public bool ShowUnsolved { get; private set; }
        public bool ShowPosted { get; private set; }

        private const string show = "show";
        private const string hide = "dontshow";

        public OverviewDisplayOption(bool showSolved, bool showUnsolved, bool showPosted)
        {
            ShowSolved = showSolved;
            ShowUnsolved = showUnsolved;
            ShowPosted = showPosted;
        }

        public override string ToString()
        {
            const string format = "OverviewDisplayOptions={\"solved\":\"{0}\"@@@\"unsolved\":\"{1}\"@@@\"posted\":\"{2}\"};";
            return string.Format(format, ShowSolved ? show : hide, ShowUnsolved ? show : hide, ShowPosted ? show : hide);
        }
    }
}
