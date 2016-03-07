using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WTM.ApiClient.Attributes;
using WTM.ApiClient.Models;

namespace WTM.ApiClient.Helpers
{
    public static class RequestToParameter
    {
        private static readonly Dictionary<Type, List<PropertyInfo>> TypePropertiesRepository = new Dictionary<Type, List<PropertyInfo>>();

        public static string ToRequestString<T>(this T instance) where T : IRequest
        {
            var properties = GetProperties<T>();

            var requestBuilder = new HttpRequestBuilder();

            foreach (var property in properties)
            {
                var name = property.Name.ToLower();
                var value = property.GetValue(instance);

                if (value == null) continue;
                
                var type = property.PropertyType;
                if (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
                {
                    type = Nullable.GetUnderlyingType(type);
                }

                var valueString = string.Empty;

                if (type == typeof(DateTime) || type == typeof(DateTimeOffset))
                {
                    var foo = value.ToString();
                    var bar = DateTime.Parse(foo);
                    valueString = bar.ToString("yyyy-MM-dd");
                }
                else
                {
                    valueString = Uri.EscapeDataString(value.ToString());
                }

                requestBuilder.AddParameter(name, valueString);
            }

            return requestBuilder.ToString();
        }

        private static IEnumerable<PropertyInfo> GetProperties<T>() where T : IRequest
        {
            List<PropertyInfo> properties;

            var type = typeof(T);

            if (TypePropertiesRepository.ContainsKey(type))
            {
                properties = TypePropertiesRepository[type];
            }
            else
            {
                properties = ReadPropertiesWithReflection<T>();
            }

            return properties;
        }

        private static List<PropertyInfo> ReadPropertiesWithReflection<T>() where T : IRequest
        {
            var type = typeof(T);
            var properties = new List<PropertyInfo>();

            foreach (var property in type.GetRuntimeProperties())
            {
                var attrs = property.GetCustomAttributes(typeof(IgnoreAttribute));

                if (attrs != null && attrs.Any())
                {
                    continue;
                }

                properties.Add(property);
            }

            TypePropertiesRepository[type] = properties;
            return properties;
        }
    }
}
