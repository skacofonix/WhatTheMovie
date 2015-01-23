using System;

namespace WTM.WebsiteClient.Application
{
    internal class WebClientWTM : WebClient
    {
        public WebClientWTM()
            : base(new Uri("http://whatthemovie.com"))
        { }
    }
}
