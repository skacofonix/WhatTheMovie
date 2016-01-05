namespace WTM.RestApi.Models
{
    public class ShotResponse : ResponseBase<IShot>
    {
        public ShotResponse(IShot shot)
        {
            this.Data = shot;
        }
    }
}
