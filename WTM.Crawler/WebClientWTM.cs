using System;

namespace WTM.Crawler
{
    public class WebClientWTM : WebClient
    {
        public WebClientWTM()
            : base(new Uri("http://whatthemovie.com"))
        { }
    }
}