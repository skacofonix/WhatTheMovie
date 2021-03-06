﻿using System;
using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class ShotSummary
    {
        [DataMember(IsRequired = true, Order = 1)]
        public int ShotId { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public Uri ImageUri { get; set; }

        [DataMember(IsRequired = true, Order = 3)]
        public ShotUserStatus UserStatus { get; set; }
    }
}