namespace WTM.Domain
{
    public interface IResponse
    {
        int Code { get; set; }

        string Message { get; set; }
    }
}