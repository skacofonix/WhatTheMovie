using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    [DataContract]
    public class Navigation : INavigation
    {
        [DataMember(EmitDefaultValue = false)]
        public int? FirstId { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public int? PreviousId { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public int? PreviousUnsolvedId { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public int? NextUnsolvedId { get; set; }
        
        [DataMember(EmitDefaultValue = false)]
        public int? NextId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? LastId { get; set; }
    }
}