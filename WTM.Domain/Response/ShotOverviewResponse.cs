namespace WTM.Domain.Response
{
    public class ShotOverviewResponse : ResponseBase<ShotOverview>
    {
        public ShotOverviewResponse(IShotOverview shotOverview)
        {
            this.Data = shotOverview as ShotOverview;
        }
    }
}
