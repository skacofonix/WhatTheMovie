using System;
using System.Collections.Generic;
using WTM.Core.Domain.BusinessEntities;

namespace WTM.WebsiteClient.Domain.BusinessEntities
{
    public class Movie : BaseClass
    {
        public string OriginalTitle { get; set; }

        public Dictionary<Culture, string> AlternativeTitle { get; set; }

        public DateTime Date { get; set; }

        public List<Shot> Shots { get; set; }
    }
}
