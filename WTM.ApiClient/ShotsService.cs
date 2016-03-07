using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using WTM.ApiClient.Helpers;
using WTM.ApiClient.Models;

namespace WTM.ApiClient
{
    public class ShotsService : IServiceOperations<WtmApi>
    {
        private readonly WtmApi client;
        private readonly Uri baseUri;

        public ShotsService(WtmApi client)
        {
            this.client = client;
            this.baseUri = new Uri(this.client.BaseUri, "api/shots/");
        }

        public WtmApi Client
        {
            get
            {
                return this.client;
            }
        }

        public async Task<HttpOperationResponse<ShotCollectionResponse>> GetShots(ShotsRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = new Uri(this.baseUri + request.ToRequestString());

            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = uri;

            cancellationToken.ThrowIfCancellationRequested();
            var httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            var statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (statusCode != HttpStatusCode.OK)
            {
                // ToDo : Manage error
            }

            var result = new HttpOperationResponse<ShotCollectionResponse>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            if (statusCode == HttpStatusCode.OK)
            {
                var resultModel = new ShotCollectionResponse();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }

            return result;
        }

        public async Task<HttpOperationResponse<ShotResponse>> GetById(ShotRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = new Uri(this.baseUri + $"{request.Id}/" + request.ToRequestString());

            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = uri;

            cancellationToken.ThrowIfCancellationRequested();
            var httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            var statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (statusCode != HttpStatusCode.OK)
            {
                // ToDo : Manage error
            }

            var result = new HttpOperationResponse<ShotResponse>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            if (statusCode == HttpStatusCode.OK)
            {
                var resultModel = new ShotResponse();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }

            return result;
        }

        public async Task<HttpOperationResponse<ShotGuessTitleResponse>> GuessTitle(GuessSolutionRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = new Uri(this.baseUri + $"guess/{request.Id}/" + request.ToRequestString());

            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = uri;

            cancellationToken.ThrowIfCancellationRequested();
            var httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            var statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (statusCode != HttpStatusCode.OK)
            {
                // ToDo : Manage error
            }

            var result = new HttpOperationResponse<ShotGuessTitleResponse>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            if (statusCode == HttpStatusCode.OK)
            {
                var resultModel = new ShotGuessTitleResponse();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }

            return result;
        }
    }
}