using System;
using System.IO;
using WTM.Core.Application;
using WTM.Test.Properties;

namespace WTM.Test.Application
{
    class StubWebClientShot : IWebClient
    {
        public System.IO.Stream GetStream(Uri uri)
        {
            var htmlContent = Resources.shot10;

            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(htmlContent);
            ms.Position = 0;

            return ms;
        }
    }
}
