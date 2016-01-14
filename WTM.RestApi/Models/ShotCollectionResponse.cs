using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotCollectionResponse : IShotCollectionResponse
    {
        public ShotCollectionResponse(DateTime date, int startIndex, int totalCount, IEnumerable<ShotSummary> items)
        {
            this.Date = date;
            this.TotalCount = totalCount;
            this.DisplayMin = startIndex;
            this.Items = items;
        }

        [Required]
        [DataMember]
        public DateTime Date { get; private set; }

        [Required]
        [DataMember]
        public int TotalCount { get; private set; }

        [Required]
        [DataMember]
        public int DisplayCount => Items.Count();

        [Required]
        [DataMember]
        public int DisplayMin { get; }

        [Required]
        [DataMember]
        public int DisplayMax => this.DisplayMin + this.DisplayCount;

        [Required]
        [DataMember]
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}