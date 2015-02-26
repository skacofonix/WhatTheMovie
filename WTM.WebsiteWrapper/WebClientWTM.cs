using System;

namespace WTM.WebsiteClient
{
    public class WebClientWTM : WebClient
    {
        public WebClientWTM()
            : base(new Uri("http://whatthemovie.com"))
        { }
    }
}