using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WTM.ApiClient.Models;

namespace WTM.ApiClient.Test
{
    [TestFixture]
    public class ShotTest
    {
        [Test]
        public void ShouldGetShots()
        {
            var foo = new Shot(new WtmApi());

            var result = foo.GetShotCollection(new ShotsRequest
            {
                Start = 10,
                Limit = 50,
                Token = Guid.NewGuid().ToString()
            });
        }
    }
}
