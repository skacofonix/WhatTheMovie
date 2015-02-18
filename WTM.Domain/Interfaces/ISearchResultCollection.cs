using System.Collections;

namespace WTM.Domain.Interfaces
{
    public interface ISearchResultCollection : IWebsiteEntity
    {
        IList Items { get; set; }

        int? Total { get; set; }

        IRange Range { get; set; }
    }
}