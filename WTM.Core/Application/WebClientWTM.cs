using System;

namespace WTM.Core.Application
{
    internal class WebClientWTM : WebClient
    {
        public WebClientWTM()
            : base(new Uri("http://whatthemovie.com"))
        { }
    }
}
