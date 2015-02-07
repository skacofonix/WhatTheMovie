using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
