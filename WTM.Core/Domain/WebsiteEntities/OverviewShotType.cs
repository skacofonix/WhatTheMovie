using System.ComponentModel;

namespace WTM.Core.Domain.WebsiteEntities
{
    enum OverviewShotType
    {
        Undefinied,

        [Description("Archive")]
        Archive,

        [Description("Feature Films")]
        FeatureFilms,

        [Description("New Submissions")]
        NewSubmissions
    }
}
