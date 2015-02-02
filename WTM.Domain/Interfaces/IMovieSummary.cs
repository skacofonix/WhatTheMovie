using System;

namespace WTM.Domain.Interfaces
{
    public interface IMovieSummary
    {
        string MovieId { get; }

        string OriginalTitle { get; }

        int? Year { get; }

        Uri Image { get; }
    }
}