using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WTM.ApiClient.Models;

namespace WTM.ApiClient.Helpers
{
    public static class RequestToParameter
    {
        private static readonly Dictionary<Type, List<PropertyInfo>> TypePropertiesRepository = new Dictionary<Type, List<PropertyInfo>>();

        public static string ToRequestString<T>(this T instance) where T : IRequest
        {
            var properties = GetPropertiesWithDataMemberAttribute<T>();

            var requestBuilder = new HttpRequestBuilder();

            foreach (var property in properties)
            {
                var name = property.Name.ToLower();
                var value = property.GetValue(instance);
                var valueString = string.Empty;

                if (value != null)
                {
                    valueString = Uri.EscapeDataString(value.ToString());
                    requestBuilder.AddParameter(name, valueString);
                }
            }

            return requestBuilder.ToString();
        }

        private static List<PropertyInfo> GetPropertiesWithDataMemberAttribute<T>() where T : IRequest
        {
            List<PropertyInfo> properties;

            var type = typeof(T);

            if (TypePropertiesRepository.ContainsKey(type))
            {
                properties = TypePropertiesRepository[type];
            }
            else
            {
                properties = ReadPropertiesWithDataMemberAttribute<T>();
            }

            return properties;
        }

        private static List<PropertyInfo> ReadPropertiesWithDataMemberAttribute<T>() where T : IRequest
        {
            var type = typeof(T);
            var properties = new List<PropertyInfo>();

            properties = type.GetRuntimeProperties().ToList();

            //foreach (var property in type.GetRuntimeProperties())
            //{
            //    var attrs = property.GetCustomAttributes(typeof (DataMemberAttribute));

            //    if (attrs == null || !attrs.Any())
            //        continue;

            //    var attr = (DataMemberAttribute) attrs.FirstOrDefault();
            //    properties.Add(property);
            //}

            TypePropertiesRepository[type] = properties;
            return properties;
        }
    }
}
