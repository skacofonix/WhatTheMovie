using System;
using System.Collections.Generic;

namespace WTM.Domain
{
    public interface IShot
    {
        int ShotId { get; set; }

        string ImageUri { get; set; }

        int? MovieId { get; set; }

        string Poster { get; set; }

        string Updater { get; set; }

        string FirstSolver { get; set; }

        int NbSolver { get; set; }

        DateTime PublidationDate { get; set; }

        DateTime SolutionDate { get; set; }

        SnapshotDifficulty? Difficulty { get; set; }

        bool IsGore { get; set; }

        bool IsNudity { get; set; }

        List<string> Tags { get; set; }

        List<string> Languages { get; set; }

        Rate Rate { get; set; }

        Movie Movie { get; set; }
    }
}