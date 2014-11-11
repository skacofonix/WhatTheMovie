using System;

namespace WTM.Core.Application
{
    public interface IWebClient
    {
        System.IO.Stream GetStream(Uri uri);
    }
}