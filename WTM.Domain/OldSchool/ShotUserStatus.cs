using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public enum ShotUserStatus
    {
        Unsolved,

        Solved,

        NeverSolved,

        Uploaded,

        Requested
    }
}