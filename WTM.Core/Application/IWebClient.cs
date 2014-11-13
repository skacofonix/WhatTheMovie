using System;
using System.IO;

namespace WTM.Core.Application
{
    public interface IWebClient
    {
        Stream GetStream(Uri uri);
    }
}