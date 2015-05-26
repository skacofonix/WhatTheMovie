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
        private ColorUserStatusConverter converter;

        [SetUp]
        public void BeforeTest()
        {
            converter = new ColorUserStatusConverter();
        }

        [Test]
        public void WhenConvertShotUserStatusValuesThenReturnColor()
        {
            Check.That(((MvxColor)converter.ConvertBack(ShotUserStatus.NeverSolved, null, null, null)).ARGB).Equals(new MvxColor(255, 0, 0).ARGB);
            Check.That(((MvxColor)converter.ConvertBack(ShotUserStatus.Requested, null, null, null)).ARGB).Equals(new MvxColor(0, 255, 0).ARGB);
            Check.That(((MvxColor)converter.ConvertBack(ShotUserStatus.Solved, null, null, null)).ARGB).Equals(new MvxColor(0, 255, 0).ARGB);
            Check.That(((MvxColor)converter.ConvertBack(ShotUserStatus.Unsolved, null, null, null)).ARGB).Equals(new MvxColor(255, 0, 0).ARGB);
            Check.That(((MvxColor)converter.ConvertBack(ShotUserStatus.Uploaded, null, null, null)).ARGB).Equals(new MvxColor(255, 255, 255).ARGB);
        }

        [Test]
        public void WhenConvertInvalidShotUserStatusThenUnsolvedColor()
        {
            Check.That(((MvxColor)converter.ConvertBack(null, null, null, null)).ARGB).Equals(new MvxColor(255, 0, 0).ARGB);
            Check.That(((MvxColor)converter.ConvertBack(new object(), null, null, null)).ARGB).Equals(new MvxColor(255, 0, 0).ARGB);
        }
    }
}