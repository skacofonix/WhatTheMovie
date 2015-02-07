namespace WTM.Domain
{
    public interface IGuessTitleResponse
    {
        bool? RightGuess { get; }

        string MovieId { get; }

        string OriginalTitle { get; }

        int? Year { get; }

        IMovie Movie { get; }
    }
}