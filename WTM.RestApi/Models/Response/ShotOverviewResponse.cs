namespace WTM.RestApi.Models.Response
{
    public class ShotOverviewResponse : ResponseBase<ShotOverview>
    {
        public ShotOverviewResponse(IShotOverview shotOverview)
        {
            this.Data = shotOverview as ShotOverview;
        }
    }
}
