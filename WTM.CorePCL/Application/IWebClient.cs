using System;

namespace WTM.CorePCL.Application
{
    public interface IWebClient
    {
        System.IO.Stream GetStream(Uri uri);
    }
}