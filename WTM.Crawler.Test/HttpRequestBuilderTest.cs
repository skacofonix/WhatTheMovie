using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WTM.Crawler.Helpers;

namespace WTM.Crawler.Test
{
    [TestFixture]
    class HttpRequestBuilderTest
    {
        [Test]
        public void ShoulMakeUrl()
        {
            var requestBuilder = new HttpRequestBuilder("prefix");
            requestBuilder.AddParameter("username", "toto");
            requestBuilder.AddParameter("password", "titi");
            requestBuilder.AddParameter("duration", "20");
            var result = requestBuilder.ToString();
        }
    }
}
