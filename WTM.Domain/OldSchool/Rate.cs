﻿using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class Rate
    {
        [DataMember(IsRequired = true)]
        public decimal Score { get; set; }

        [DataMember(IsRequired = true)]
        public int NbRaters { get; set; }
    }
}