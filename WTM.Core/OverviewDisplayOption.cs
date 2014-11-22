using System.Net;

namespace WTM.Core
{
    class OverviewDisplayOption
    {
        public bool ShowSolved
        {
            get { return showSolved; }
            set
            {
                showSolved = value;
                GenerateCookie();
            }
        }
        private bool showSolved;

        public bool ShowUnsolved
        {
            get { return showUnsolved; }
            set
            {
                showUnsolved = value;
                GenerateCookie();                
            }
        }
        private bool showUnsolved;

        public bool ShowPosted
        {
            get { return showPosted; }
            set
            {
                showPosted = value;
                GenerateCookie();                
            }
        }
        private bool showPosted;

        public Cookie CookieOverviewDisplayOption { get; private set; }

        public OverviewDisplayOption()
        {
            GenerateCookie();
        }

        private const string show = "show";
        private const string hide = "dontshow";

        public override string ToString()
        {
            const string format = "{\"solved\":\"{0}\"@@@\"unsolved\":\"{1}\"@@@\"posted\":\"{2}\"}";
            return string.Format(format,
                ShowSolved ? show : hide,
                ShowUnsolved ? show : hide,
                ShowPosted ? show : hide);
        }

        private void GenerateCookie()
        {
            CookieOverviewDisplayOption = new Cookie("OverviewDisplayOptions", ToString());
        }
    }
}
