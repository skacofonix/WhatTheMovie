using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotArchivesResponse : IShotCollectionResponse
    {
        public ShotArchivesResponse(DateTime date, int startIndex, int totalCount, IEnumerable<IShotSummary> items)
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
        public int TotalCount { get; }

        [Required]
        [DataMember]
        public int DisplayCount { get; }

        [Required]
        [DataMember]
        public int DisplayMin { get; }

        [Required]
        [DataMember]
        public int DisplayMax { get; }

        [Required]
        [DataMember]
        public IEnumerable<IShotSummary> Items { get; private set; }
    }
}