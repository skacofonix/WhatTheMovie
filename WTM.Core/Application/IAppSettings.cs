namespace WTM.Core.Application
{
    public interface IAppSettings
    {
        string Proxy { get; set; }
        string UserAgent { get; set; }
    }
}