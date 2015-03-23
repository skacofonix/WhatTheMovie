using Cirrious.CrossCore.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace WTM.Mobile.Core.Converters
{
    public class StringListValueConverter : MvxValueConverter<IList<string>, string>
    {
        protected override string Convert(IList<string> value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var separator = ", ";
            if (parameter != null)
            {
                var customDelimiter = parameter as string;
                if (customDelimiter != null)
                    separator = customDelimiter;
            }

            return string.Join(separator, value);
        }
    }
}