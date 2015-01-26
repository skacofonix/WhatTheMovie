namespace WTM.Core
{
    public interface IDisplayOptions
    {
        bool ShowSolvedShot { get; }
        bool ShowUnsolvedShot { get; }
        bool ShowPostedShot { get; }

        bool FilterGore { get; }
        bool FilterNudity { get; }
    }
}