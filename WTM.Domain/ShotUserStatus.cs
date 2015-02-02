using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public enum ShotUserStatus
    {
        Unsolved,

        Solved,

        NeverSolved,

        Uploaded
    }
}