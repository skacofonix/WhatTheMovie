using System;

namespace WTM.Domain.Interfaces
{
    public interface IMemorabilia
    {
        string Title { get; }

        string Tag { get; }

        string Description { get; }

        Uri Image { get; }
    }
}