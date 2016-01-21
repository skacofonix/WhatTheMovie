using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    public interface IPaginableRequest
    {
        [DataMember]
        int? Start { get; }

        [DataMember]
        int? Limit { get; }
    } 
}