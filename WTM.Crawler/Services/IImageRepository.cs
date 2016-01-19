using System;
using System.ComponentModel;

namespace WTM.Crawler.Services
{
    public interface IImageRepository
    {
        void Add(string id, byte[] data);
        byte[] Get(string id);
    }
}