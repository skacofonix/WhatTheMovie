using WTM.Domain.Interfaces;

namespace WTM.Crawler.Services
{
    public interface IReadWriteService<T> where T : IWebsiteEntity
    {
        T Read();

        bool Write(T instance);
    }
}