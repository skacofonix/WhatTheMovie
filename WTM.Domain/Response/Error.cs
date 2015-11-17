namespace WTM.Domain.Response
{
    public abstract class Error
    {
        public int Code { get; set; }

        public string Message { get; set; }
    }
}