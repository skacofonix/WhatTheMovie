using System;
using NFluent;
using NUnit.Framework;
using WTM.WebsiteClient.Application;

namespace WTM.WebsiteClient.Test.Application
{
    [TestFixture]
    public class ServerDateTimeTest
    {
        [Test]
        public void WhenInvokeGetDateTimeMethodThenReturnDateTimeOfTheServer()
        {
            var serverDateTime = new ServerDateTime();
            Check.That(serverDateTime.GetDateTime()).IsNotEqualTo(DateTime.MinValue);
        }
    }
}