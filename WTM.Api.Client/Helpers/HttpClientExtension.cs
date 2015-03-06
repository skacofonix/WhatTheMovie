using System;
using System.Net.Http;

namespace WTM.Api.Client.Helpers
{
    internal static class HttpClientExtension
    {
        public static T GetObjectSync<T>(this HttpClient httpClient, Uri uri)
        {
            T result = default(T);
            var task = httpClient.GetStringAsync(uri).ContinueWith(r =>
            {
                result = r.Result.Deserialize<T>();
            });
            task.Wait();
            return result;
        }
    }
}