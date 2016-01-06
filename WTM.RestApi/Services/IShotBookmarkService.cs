namespace WTM.RestApi.Services
{
    public interface IShotBookmarkService
    {
        ShotBookmarkAddResponse Add(int id, string token);

        ShotBookmarkDeleteResponse Delete(int id, string token);

        ShotBookmarkResponse Get(string token, int? start, int? limit);
    }
}