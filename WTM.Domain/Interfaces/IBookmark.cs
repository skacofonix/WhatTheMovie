using System;
using System.Collections.Generic;
using System.Text;

namespace WTM.Domain.Interfaces
{
    public interface IBookmark : IWebsiteEntity
    {
        string ShotUrl { get; set; }

        int? ShotId { get; set; }

        string ImageUrl { get; set; }

        int? NbDaysLeft { get; set; }

        bool SolutionAvailable { get; set; }
    }
}
