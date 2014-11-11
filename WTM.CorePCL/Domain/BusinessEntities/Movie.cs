using System;
using System.Collections.Generic;
using WTM.CorePCL.Domain.BusinessEntities.Base;

namespace WTM.CorePCL.Domain.BusinessEntities
{
    public class Movie : BaseClass
    {
        public string OriginalTitle { get; set; }

        public Dictionary<Culture, string> AlternativeTitle { get; set; }

        public DateTime Date { get; set; }

        public List<Shot> Shots { get; set; }
    }
}
