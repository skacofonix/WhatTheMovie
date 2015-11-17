namespace WTM.Domain.OldSchool
{
    public sealed class SnapshotDifficultyChoiceEasy : SnapshotDifficultyChoice
    {
        public override SnapshotDifficulty Difficulty
        {
            get { return SnapshotDifficulty.Easy; }
        }

        public override string ToString()
        {
            return "easy";
        }
    }
}