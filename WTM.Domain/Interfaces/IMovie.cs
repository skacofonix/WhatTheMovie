using System;
using System.Collections.Generic;

namespace WTM.Domain
{
    public interface IMovie
    {
        string OriginalTitle { get;  }

        IList<string> GenreList { get;  }

        string Director { get;  }

        string Abstract { get;  }

        int? Year { get;  }

        IRate Rate { get; }

        IList<string> AlternativeTitles { get; }

        IList<string> Tags { get; }

        int? NumberOfSnapshot { get; }

        double? TotalSolves { get; }

        DateTime? IntroducedOn { get; }

        string IntroducedBy { get; }

        int? NumberOfReviews { get; }
    }
}