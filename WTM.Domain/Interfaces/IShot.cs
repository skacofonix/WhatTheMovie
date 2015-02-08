﻿using System;
using System.Collections.Generic;

namespace WTM.Domain
{
    public interface IShot
    {
        int ShotId { get; }

        string ImageUri { get;  }

        string MovieId { get;  }

        string Poster { get;  }

        string Updater { get;  }

        string FirstSolver { get;  }

        int NbSolver { get;  }

        DateTime PublidationDate { get;  }

        DateTime SolutionDate { get;  }

        SnapshotDifficulty? Difficulty { get;  }

        ShotUserStatus UserStatus { get; }

        bool IsGore { get;  }

        bool IsNudity { get;  }

        IList<string> Tags { get;  }

        IList<string> Languages { get;  }

        IRate Rate { get;  }

        Movie Movie { get;  }
    }
}