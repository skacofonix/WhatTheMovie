using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public abstract class SnapshotDifficultyChoice
    {
        public abstract SnapshotDifficulty Difficulty { get; }
    }
}