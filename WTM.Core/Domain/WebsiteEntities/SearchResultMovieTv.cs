using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Core.Domain.WebsiteEntities
{
    internal class SearchResultMovieTv : SearchResultBase
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        public string MovieUrl { get; set; }
    }
}
