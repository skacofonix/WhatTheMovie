using System;

namespace WTM.WebsiteClient.Application
{
    public class WebClientWTM : WebClient
    {
        public WebClientWTM()
            : base(new Uri("http://whatthemovie.com"))
        { }
    }
}
