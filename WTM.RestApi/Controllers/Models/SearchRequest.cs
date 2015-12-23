using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WTM.RestApi.Controllers.Models
{
    public class SearchRequest
    {
        [Required]
        public string Filter { get; set; }

        public int? Start { get; set; }

        [Range(5, 100)]
        public int? Limit { get; set; }
    }
}