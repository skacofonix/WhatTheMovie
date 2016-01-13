using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    public class ShotsResponse : IShotsResponse
    {
        public ShotsResponse(DateTime date, int startIndex, int totalCount, IEnumerable<ShotSummary> items)
        {
            this.Date = date;
            this.TotalCount = totalCount;
            this.DisplayMin = startIndex;
            this.Items = items;
        }

        [Required]
        public DateTime Date { get; private set; }

        [Required]
        public int TotalCount { get; private set; }

        [Required]
        public int DisplayCount => Items.Count();

        [Required]
        public int DisplayMin { get; }

        [Required]
        public int DisplayMax => this.DisplayMin + this.DisplayCount;

        [Required]
        public IEnumerable<ShotSummary> Items { get; private set; }
    }
}