using System;
using Cirrious.CrossCore.UI;
using NFluent;
using NUnit.Framework;
using WTM.Domain;
using WTM.Mobile.Core.Converters;

namespace WTM.Mobile.Core.Test
{
    [TestFixture]
    public class ColorUserStatusConverterTest
    {
        private ColorUserStatusValueConverter valueConverter;

        [SetUp]
        public void BeforeTest()
        {
            valueConverter = new ColorUserStatusValueConverter();
        }

        [Test]
        public void WhenConvertShotUserStatusValuesThenReturnColor()
        {
            Check.That(((MvxColor)valueConverter.ConvertBack(ShotUserStatus.NeverSolved, null, null, null)).ARGB).Equals(new MvxColor(255, 0, 0).ARGB);
            Check.That(((MvxColor)valueConverter.ConvertBack(ShotUserStatus.Requested, null, null, null)).ARGB).Equals(new MvxColor(0, 255, 0).ARGB);
            Check.That(((MvxColor)valueConverter.ConvertBack(ShotUserStatus.Solved, null, null, null)).ARGB).Equals(new MvxColor(0, 255, 0).ARGB);
            Check.That(((MvxColor)valueConverter.ConvertBack(ShotUserStatus.Unsolved, null, null, null)).ARGB).Equals(new MvxColor(255, 0, 0).ARGB);
            Check.That(((MvxColor)valueConverter.ConvertBack(ShotUserStatus.Uploaded, null, null, null)).ARGB).Equals(new MvxColor(255, 255, 255).ARGB);
        }

        [Test]
        public void WhenConvertInvalidShotUserStatusThenUnsolvedColor()
        {
            Check.That(((MvxColor)valueConverter.ConvertBack(null, null, null, null)).ARGB).Equals(new MvxColor(255, 0, 0).ARGB);
            Check.That(((MvxColor)valueConverter.ConvertBack(new object(), null, null, null)).ARGB).Equals(new MvxColor(255, 0, 0).ARGB);
        }
    }
}