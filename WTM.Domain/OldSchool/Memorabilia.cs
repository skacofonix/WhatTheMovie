using System;
using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class Memorabilia
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