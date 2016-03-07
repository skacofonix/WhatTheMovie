using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WTM.ApiClient.Attributes;

namespace WTM.ApiClient.Models
{
    public partial class ShotRequest : IRequest
    {
        [Ignore]
        public int Id { get; set; }
    }
}