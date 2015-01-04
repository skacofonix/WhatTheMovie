using System.ComponentModel;

namespace WTM.Core.Helpers
{
    public static class EnumHelpers
    {
        public static string GetDescription<T>(T source) where T : struct
        {
            var fieldInfo = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            return source.ToString();
        }
    }
}
