using WTM.Crawler.Domain;

namespace WTM.Crawler.Services
{
    public interface IReadWriteService<T> where T : IWebsiteEntity
    {
        T Read();

        bool Write(T instance);
    }
}