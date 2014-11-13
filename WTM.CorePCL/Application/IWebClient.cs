using System;
using System.IO;

namespace WTM.CorePCL.Application
{
    public interface IWebClient
    {
        Stream GetStream(Uri uri);
    }
}