﻿using System;

namespace WTM.RestApi.Models.Request
{
    public class GetArchivesRequest : IPaginableRequest, IAuthenticableRequest
    {
        public DateTime? Date { get; set; }

        public int? Limit { get; set; }

        public int? Start { get; set; }

        public string Token { get; set; }
    }
}