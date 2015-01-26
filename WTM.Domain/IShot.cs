using System;
using System.Collections.Generic;

namespace WTM.Domain
{
    public interface IShot
    {
        int WtmId { get; set; }
        string ImageUri { get; set; }
        User PostedBy { get; set; }
        User FirstSolvedBy { get; set; }
        DateTime PublidationDate { get; set; }
        SnapshotDifficulty Difficulty { get; set; }
        bool IsGore { get; set; }
        bool IsNudity { get; set; }
        List<Tag> Tags { get; set; }
        Movie Movie { get; set; }
        int DayRemainingBeforeSolution { get; set; }
        DateTime DateSolution { get; set; }
    }
}