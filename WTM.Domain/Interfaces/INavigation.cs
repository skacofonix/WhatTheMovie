namespace WTM.Domain
{
    public interface INavigation
    {
        int? FirstId { get;  }

        int? PreviousId { get;  }

        int? PreviousUnsolvedId { get;  }

        int? NextUnsolvedId { get;  }

        int? NextId { get;  }

        int? LastId { get;  }
    }
}