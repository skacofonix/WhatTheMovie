using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    public enum ShotUserStatus
    {
        NotConnected,

        Unsolved,

        Solved,

        NeverSolved,

        Uploaded,

        Requested
    }
}