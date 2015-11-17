namespace WTM.Domain.OldSchool
{
    public sealed class SnapshotDifficultyChoiceAll : SnapshotDifficultyChoice
    {
        public override SnapshotDifficulty Difficulty
        {
            get { return SnapshotDifficulty.Easy | SnapshotDifficulty.Medium | SnapshotDifficulty.Hard; }
        }

        public override string ToString()
        {
            return "all";
        }
    }
}