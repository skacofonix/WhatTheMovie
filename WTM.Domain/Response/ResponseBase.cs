namespace WTM.Domain.Response
{
    public abstract class ResponseBase<T> where T : IModelBase
    {
        public T Data { get; set; }

        public Pagination Pagination { get; set; }

        public Error Error { get; set; }
    }
}