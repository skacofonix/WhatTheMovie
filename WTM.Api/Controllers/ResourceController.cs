using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WTM.Api.Controllers
{
    public class ResourceController : BaseController
    {
        public HttpResponseMessage GetImage([FromBody]Uri resource, [FromBody]string referer)
        {
            var webClient = new System.Net.WebClient();
            webClient.Headers = new WebHeaderCollection();
            webClient.Headers["Referer"] = WebUtility.UrlDecode(referer);

            var stream = webClient.OpenRead(resource);
            var ms = new MemoryStream();
            stream.CopyTo(ms);

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(ms.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            return result;
        }
    }
}
