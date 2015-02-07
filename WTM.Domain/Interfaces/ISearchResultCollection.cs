using System.Collections;
using WTM.Domain.Interfaces;

namespace WTM.WebsiteClient.Domain
{
    public interface ISearchResultCollection : IWebsiteEntity
    {
        IList Items { get; set; }
    }
}