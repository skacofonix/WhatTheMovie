using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    [DataContract]
    public class Rate : IRate
    {
        [DataMember(IsRequired = true)]
        public decimal Score { get; set; }

        [DataMember(IsRequired = true)]
        public int NbRaters { get; set; }
    }
}