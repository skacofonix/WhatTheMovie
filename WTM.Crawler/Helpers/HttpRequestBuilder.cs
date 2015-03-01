using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WTM.Crawler.Helpers
{
    internal class HttpRequestBuilder
    {
        private readonly Dictionary<string, string> parameters;

        public HttpRequestBuilder()
        {
            parameters = new Dictionary<string, string>();
        }

        public void AddParameter(string key, string value)
        {
            parameters[key] = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (parameters.Count > 0)
                AppendParameter(sb, parameters.First());

            if (parameters.Count > 1)
            {
                for (var index = 1; index < parameters.Count; index++)
                {
                    sb.Append("&");
                    AppendParameter(sb, parameters.ElementAt(index));
                }
            }

            return sb.ToString();
        }

        private static void AppendParameter(StringBuilder sb, KeyValuePair<string, string> keyValuePair)
        {
            sb.Append(keyValuePair.Key);
            sb.Append("=");
            sb.Append(keyValuePair.Value);
        }
    }
}