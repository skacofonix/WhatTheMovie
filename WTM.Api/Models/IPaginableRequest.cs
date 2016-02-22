using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    public interface IPaginableRequest
    {
        [DataMember]
        int? Start { get; }

        [DataMember]
        [Range(5, 100)]
        int? Limit { get; }
    } 
}