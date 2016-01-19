using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Web.Hosting;
using System.Web.Http;
using WTM.Crawler.Services;

namespace WTM.RestApi.Controllers
{
    [RoutePrefix("api/images")]
    public class ResourcesController : ApiController
    {
        private readonly IImageRepository imageRepository;

        public ResourcesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [Route("shots")]
        [HttpGet]
        public HttpResponseMessage GetShot(string id)
        {
            var rawData = this.imageRepository.Get(id);
            var ms = new MemoryStream(rawData);

            var result = new HttpResponseMessage(HttpStatusCode.OK);

            //String filePath = HostingEnvironment.MapPath("~/Images/HT.jpg");
            //FileStream fileStream = new FileStream(filePath, FileMode.Open);
            //Image image = Image.FromStream(fileStream);
            //image.Save(ms, ImageFormat.Jpeg);

            result.Content = new ByteArrayContent(rawData);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return result;
        }
    }
}