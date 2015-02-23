using System.Net;

namespace WTM.Domain.Interfaces
{
    public interface IOverviewDisplayOptions : IWebsiteEntity
    {
        bool ShowSolved { get; set; }
        
        bool ShowUnsolved { get; set; }
        
        bool ShowPosted { get; set; }
    }
}