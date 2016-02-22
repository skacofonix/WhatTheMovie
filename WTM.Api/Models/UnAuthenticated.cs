using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    public class UnAuthenticated : IAuthenticated
    {
        public UnAuthenticated()
        {
            this.IsAuthenticated = false;
            this.User = null;
        }

        [Required]
        public bool IsAuthenticated { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public IUserSummary User { get; private set; }
    }
}