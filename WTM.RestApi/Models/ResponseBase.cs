using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    public abstract class ResponseBase<T> where T : IModelBase
    {
        public T Data { get; set; }

        public IPaginable Pagination { get; set; }

        public Error Error { get; set; }
    }
}