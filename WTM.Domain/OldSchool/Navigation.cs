using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class Navigation
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