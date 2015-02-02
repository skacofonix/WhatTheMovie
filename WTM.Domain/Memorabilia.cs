using System;
using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class Memorabilia : IMemorabilia
    {
        [DataMember(IsRequired = true)]
        public string Title { get; private set; }

        [DataMember(IsRequired = true)]
        public string Tag { get; private set; }

        [DataMember(IsRequired = true)]
        public string Description { get; private set; }

        [DataMember(IsRequired = true)]
        public Uri Image { get; private set; }
    }
}