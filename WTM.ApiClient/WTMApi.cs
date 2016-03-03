using System;
using Microsoft.Rest;

namespace WTM.ApiClient
{
    public class WTMApi : ServiceClient<WTMApi>
    {
        private readonly Uri baseUri;

        public WTMApi()
        {
            this.baseUri = new Uri("http://localhost:19889");
        }

        public Uri BaseUri => baseUri;
    }
}