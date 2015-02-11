using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public abstract class SnapshotDifficultyChoice : ISnapshotDifficultyChoice
    {
        public abstract SnapshotDifficulty Difficulty { get; }
    }
}