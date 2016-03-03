using System;
using Microsoft.Rest;

namespace WTM.ApiClient
{
    public class WtmApi : ServiceClient<WtmApi>
    {
        private readonly Uri baseUri;

        public WtmApi()
        {
            this.baseUri = new Uri("http://localhost:19889");
        }

        public Uri BaseUri => baseUri;
    }
}