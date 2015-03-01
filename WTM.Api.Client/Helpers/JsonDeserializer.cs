using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WTM.Api.Client.Helpers
{
    public static class JsonDeserializer
    {
        public static T Deserialize<T>(this string s)
        {
            if(s == null)
                throw new ArgumentNullException();
            if(string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("String is null or whitespace", "s");

            var json = JObject.Parse(s);
            var jsonReader = json.CreateReader();
            var jsonSerialializer = JsonSerializer.Create();
            var instance = jsonSerialializer.Deserialize<T>(jsonReader);

            return instance;
        }
    }
}
