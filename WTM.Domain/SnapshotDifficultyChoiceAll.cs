namespace WTM.Domain
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