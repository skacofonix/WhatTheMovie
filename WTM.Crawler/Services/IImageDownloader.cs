using System;

namespace WTM.Crawler.Services
{
    public interface IImageDownloader
    {
        byte[] Get(Uri uri, string referer);
    }
}