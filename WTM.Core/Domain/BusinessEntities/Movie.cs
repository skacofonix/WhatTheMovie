using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Core.Domain.BusinessEntities.Base;

namespace WTM.Core.Domain.BusinessEntities
{
    public class Movie : BaseClass
    {
        public string OriginalTitle { get; set; }

        public Dictionary<Culture, string> AlternativeTitle { get; set; }

        public DateTime Date { get; set; }

        public List<Shot> Shots { get; set; }
    }
}
