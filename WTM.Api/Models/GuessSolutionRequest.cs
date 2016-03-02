﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    [DataContract]
    public class GuessSolutionRequest : IGuessSolutionRequest
    {
        [Required]
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Token { get; set; }
    }
}