namespace WTM.Api2.Models.Response
{
    public abstract class ResponseBase<T> where T : ModelBase
    {
        public T Data { get; set; }

        public Pagination Pagination { get; set; }

        public Error Error { get; set; }
    }
}