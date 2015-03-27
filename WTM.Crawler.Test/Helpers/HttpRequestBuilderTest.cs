using NFluent;
using NUnit.Framework;
using WTM.Common.Helpers;

namespace WTM.Crawler.Test.Helpers
{
    [TestFixture]
    public class HttpRequestBuilderTest
    {
        [Test]
        public void WhenBuildPutRequestThenRetunrnFormattedString()
        {
            var putRequestBuilder = new HttpRequestBuilder();
            putRequestBuilder.AddParameter("_method", "put");
            putRequestBuilder.AddParameter("user[prefers_arrow_keys_nav]", "true");
            putRequestBuilder.AddParameter("user[prefers_filter_gore]", "false");
            putRequestBuilder.AddParameter("user[prefers_filter_nudity]", "false");
            putRequestBuilder.AddParameter("user[notification_acceptedshot]", "email");
            putRequestBuilder.AddParameter("user[notification_rejectedshot]", "email");
            putRequestBuilder.AddParameter("user[notification_deletedshot]", "email");
            putRequestBuilder.AddParameter("user[notification_friendrequest]", "email");
            putRequestBuilder.AddParameter("user[prefers_newsletter]", "true");
            const string expected = "_method=put&user[prefers_arrow_keys_nav]=true&user[prefers_filter_gore]=false&user[prefers_filter_nudity]=false&user[notification_acceptedshot]=email&user[notification_rejectedshot]=email&user[notification_deletedshot]=email&user[notification_friendrequest]=email&user[prefers_newsletter]=true";

            Check.That(putRequestBuilder.ToString()).Equals(expected);
        }
    }
}