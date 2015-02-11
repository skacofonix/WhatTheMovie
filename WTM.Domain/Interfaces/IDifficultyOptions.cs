namespace WTM.Domain.Interfaces
{
    public interface IDifficultyOptions : IWebsiteEntity
    {
        ISnapshotDifficultyChoice SnapshotDifficultyFilter { get; }

        int? NumberOfShotEasy { get; }

        int? NumberOfShotMedium { get; }

        int? NumberOfShotHard { get; }

        string TagFilter { get; }

        bool IncludeArchive { get; }

        bool IncludeSolvedShots { get; }
    }
}