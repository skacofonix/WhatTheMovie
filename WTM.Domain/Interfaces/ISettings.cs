using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public interface ISettings : IWebsiteEntity
    {
        bool? ShowGore { get; set; }
        bool? ShowNudity { get; set; }
    }
}