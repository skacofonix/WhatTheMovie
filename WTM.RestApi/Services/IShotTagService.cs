namespace WTM.RestApi.Services
{
    public interface IShotTagService
    {
        ShotTagAddResponse Add(string tag, string token);
        ShotTagDeleteResponse Delete(string tag, string token);
    }
}