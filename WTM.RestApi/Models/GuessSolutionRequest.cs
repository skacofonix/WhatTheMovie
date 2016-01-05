﻿using System.ComponentModel.DataAnnotations;

namespace WTM.RestApi.Models
{
    public class GuessSolutionRequest : IRequest, IAuthenticable
    {
        [Required]
        public string Title { get; set; }

        public string Token { get; set; }
    }
}