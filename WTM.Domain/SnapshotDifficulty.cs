﻿using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public enum SnapshotDifficulty
    {
        Easy,

        Medium,

        Hard
    }
}