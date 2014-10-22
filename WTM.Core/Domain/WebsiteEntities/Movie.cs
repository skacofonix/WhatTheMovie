using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Domain.WebsiteEntities
{
    class Movie : IMovie
    {
        public string OriginalTitle { get; set; }
    }
}
