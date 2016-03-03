using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace WTM.ApiClient
{
    public class Shot : IServiceOperations<WTMApi>
    {
        private readonly WTMApi client;
        private readonly Uri baseUri;

        public Shot(WTMApi client)
        {
            this.client = client;
            this.baseUri = new Uri(this.client.BaseUri, "api/shots");
        }

        public WTMApi Client
        {
            get
            {
                return this.client;
            }
        }

        //public async Task<HttpOperationResponse<ShotCollectionResponse>> GetShotCollection(ShotsRequest request)
        //{
        //    // Build URL
        //    var result = new HttpOperationResponse<ShotCollectionResponse>();
        //    return result;
        //}
    }
}