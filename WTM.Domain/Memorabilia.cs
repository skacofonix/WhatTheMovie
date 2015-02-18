using System;
using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    [DataContract]
    public class Memorabilia : IMemorabilia
    {
        [DataMember(IsRequired = true)]
        public string Title { get; set; }

        [DataMember(IsRequired = true)]
        public string Tag { get; set; }

        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        [DataMember(IsRequired = true)]
        public Uri Image { get; set; }
    }
}