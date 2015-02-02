namespace WTM.Domain
{
    public interface INavigation
    {
        int? FirstiId { get;  }

        int? PreviousId { get;  }

        int? PreviousUnsolvedId { get;  }

        int? NextUnsolvedId { get;  }

        int? NextId { get;  }

        int? LastId { get;  }
    }
}