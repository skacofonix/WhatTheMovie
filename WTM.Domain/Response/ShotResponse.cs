namespace WTM.Domain.Response
{
    public class ShotResponse : ResponseBase<IShot>
    {
        public ShotResponse(IShot shot)
        {
            this.Data = shot;
        }
    }
}
