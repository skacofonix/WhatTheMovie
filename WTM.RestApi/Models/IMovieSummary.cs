using System;

namespace WTM.RestApi.Models
{
    public interface IMovieSummary
    {
        string Id { get; }

        string Title { get; }

        int Year { get; }

        Uri Image { get; }
    }
}