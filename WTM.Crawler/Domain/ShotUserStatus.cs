using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
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