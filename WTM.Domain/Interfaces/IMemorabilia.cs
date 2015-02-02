using System;

namespace WTM.Domain
{
    public interface IMemorabilia
    {
        string Title { get; }

        string Tag { get; }

        string Description { get; }

        Uri Image { get; }
    }
}