using NFluent;
using NUnit.Framework;
using System.Text.RegularExpressions;
using WTM.Crawler.Extensions;

namespace WTM.Crawler.Test.Extensions
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void WhenExtractValueFromStringThenReturnExtractedValue()
        {
            Check.That("abc".ExtractValue(new Regex("(a)"))).Equals("a");
            Check.That("abc".ExtractValue(new Regex("(b)"))).Equals("b");
            Check.That("abc".ExtractValue(new Regex("(ab)"))).Equals("ab");
            Check.That("aBc".ExtractValue(new Regex("(b)", RegexOptions.IgnoreCase))).Equals("B");
        }

        [Test]
        public void WhenExtractAndParseIntThenReturnInteger()
        {
            Check.That("1".ExtractAndParseInt(new Regex(@"(\d)"))).Equals(1);
            Check.That("42".ExtractAndParseInt(new Regex(@"(\d*)"))).Equals(42);

            // Strange ? WTF ?!!!!!!
            Check.That("price: 42$".ExtractAndParseInt(new Regex(@"(\d*)", RegexOptions.None))).Equals(42);
        }
    }
}