using System;
using NFluent;
using NUnit.Framework;
using WTM.Core.Application;

namespace WTM.Core.Test.Application
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