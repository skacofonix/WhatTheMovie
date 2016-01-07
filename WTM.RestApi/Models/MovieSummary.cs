using System;
using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class MovieSummary : IMovieSummary
    {
        [Required]  
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1895, 3000)]
        public int Year { get; set; }

        [Required]
        public Uri Image { get; set; }
    }
}