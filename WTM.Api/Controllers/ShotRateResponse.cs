using System.Runtime.Serialization;
using WTM.Api.Domain;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    [DataContract]
    public class ShotRateResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public Rate Rate { get; set; }
    }
}