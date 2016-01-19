using System;
using System.Collections.Generic;

namespace WTM.Crawler.Services
{
    public class ImageRepository : IImageRepository
    {
        private readonly IDictionary<string, byte[]> foo = new Dictionary<string, byte[]>(); 

        public void Add(string id, byte[] data)
        {
            foo[id] = data;
        }

        public byte[] Get(string id)
        {
            byte[] data = null;

            if (foo.ContainsKey(id))
            {
                data = foo[id];
            }

            return data;
        }
    }
}