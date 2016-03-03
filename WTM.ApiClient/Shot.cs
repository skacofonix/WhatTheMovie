using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Rest;
using WTM.ApiClient.Models;

namespace WTM.ApiClient
{
    public class Shot : IServiceOperations<WtmApi>
    {
        private readonly WtmApi client;
        private readonly Uri baseUri;

        public Shot(WtmApi client)
        {
            this.client = client;
            this.baseUri = new Uri(this.client.BaseUri, "api/shots");
        }

        public WtmApi Client
        {
            get
            {
                return this.client;
            }
        }

        public async Task<HttpOperationResponse<ShotCollectionResponse>> GetShotCollection(ShotsRequest request)
        {
            // Build URL




            var result = new HttpOperationResponse<ShotCollectionResponse>();
            return result;
        }
    }
}