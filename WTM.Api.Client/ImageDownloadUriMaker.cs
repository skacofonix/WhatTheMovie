using System;
using System.Net;
using WTM.Common.Helpers;

namespace WTM.Api.Client
{
    public class ImageDownloadUriMaker
    {
        private readonly Uri baseUri;

        public ImageDownloadUriMaker(Uri baseUri)
        {
            this.baseUri = new Uri(baseUri, "Shot/");
        }

        public Uri MakeUri(Uri uriImage, string referer)
        {
            if (uriImage == null)
                return null;

            if (referer == null)
                return uriImage;

            var requestBuilder = new HttpRequestBuilder("Shot");
            requestBuilder.AddParameter("image", WebUtility.UrlEncode(uriImage.ToString()));
            requestBuilder.AddParameter("referer", WebUtility.UrlEncode(referer));

            var uri = new Uri(baseUri, requestBuilder.ToString());

            return uri;
        }
    }
}