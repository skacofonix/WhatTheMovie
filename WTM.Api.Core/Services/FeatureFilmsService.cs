using System;
using System.Collections.Generic;
using WTM.Domain;

namespace WTM.Api.Core.Services
{
    public class FeatureFilmsService : ShotService, IShotOverview
    {
        public FeatureFilmsService(IContext context)
            : base(context)
        { }

        public IEnumerable<IShotSummary> GetShotSummary(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
