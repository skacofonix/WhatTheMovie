using System;

namespace WTM.Api.Models
{
    public interface IMovieSummary
    {
        string Id { get; }

        string Title { get; }

        int Year { get; }

        Uri Image { get; }
    }
}