using System;
using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    [Flags]
    public enum SnapshotDifficulty
    {
        Easy = 1,

        Medium = 2,

        Hard = 4
    }
}