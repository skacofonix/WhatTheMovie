using System.Runtime.Serialization;

namespace WTM.Api
{
    [DataContract]
    public class Error
    {
        [DataMember(IsRequired = true, Order = 1)]
        public int Code { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public string Message { get; set; }

        [DataMember(IsRequired = false, Order = 3, EmitDefaultValue = false)]
        public object[] Data { get; set; }
    }
}
