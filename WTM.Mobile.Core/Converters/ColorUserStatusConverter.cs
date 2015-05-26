using Cirrious.CrossCore.UI;
using Cirrious.MvvmCross.Plugins.Color;
using System;
using System.Globalization;
using WTM.Domain;

namespace WTM.Mobile.Core.Converters
{
    public class ColorUserStatusConverter : MvxNativeColorValueConverter
    {
        protected override MvxColor Convert(MvxColor value, object parameter, CultureInfo culture)
        {
            return base.Convert(value, parameter, culture);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = new MvxColor(255, 0, 0);

            if (value == null)
                return color;

            if(!(value is ShotUserStatus))
                return color;

            var shotUserStatus = (ShotUserStatus) value;
            switch (shotUserStatus)
            {
                case ShotUserStatus.Unsolved:
                    color = new MvxColor(255, 0, 0);
                    break;
                case ShotUserStatus.Solved:
                    color = new MvxColor(0, 255, 0);
                    break;
                case ShotUserStatus.NeverSolved:
                    color = new MvxColor(255, 0, 0);
                    break;
                case ShotUserStatus.Uploaded:
                    color = new MvxColor(255, 255, 255);
                    break;
                case ShotUserStatus.Requested:
                    color = new MvxColor(0, 255, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return color;
        }
    }
}
