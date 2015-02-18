namespace WTM.Domain.Interfaces
{
    public interface ISettings : IWebsiteEntity
    {
        bool? ShowGore { get; set; }
        bool? ShowNudity { get; set; }
    }
}