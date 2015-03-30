using System;
using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public object[] Data { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Exception Exception { get; set; }
    }
}