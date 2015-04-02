using Cirrious.CrossCore.Converters;
using System;

namespace WTM.Mobile.Core.Converters
{
    public class StringFormatValueConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (parameter == null)
                return value;

            var format = "{0:" + parameter.ToString() + "}";

            return string.Format(format, value);
        }
    }
}
