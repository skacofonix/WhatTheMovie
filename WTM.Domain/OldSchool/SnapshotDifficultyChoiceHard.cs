namespace WTM.Domain.OldSchool
{
    public sealed class SnapshotDifficultyChoiceHard : SnapshotDifficultyChoice
    {
        public override SnapshotDifficulty Difficulty
        {
            get { return SnapshotDifficulty.Hard; }
        }

        public override string ToString()
        {
            return "hard";
        }
    }
}