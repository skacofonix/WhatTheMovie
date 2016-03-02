using System;
using Microsoft.Rest;

namespace WTM.ApiClient
{
    public class WTMApi : ServiceClient<WTMApi>
    {
        public WTMApi()
        {
            this.BaseUri = new Uri("http://localhost:19889");
        }

        public Uri BaseUri { get; set; }
    }
}