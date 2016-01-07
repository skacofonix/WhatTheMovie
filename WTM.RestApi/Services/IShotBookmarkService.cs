using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotBookmarkService
    {
        ShotBookmarkResponse Get(BookmarksGetRequest request);
        ShotBookmarkAddResponse Add(int id, BookmarksAddRequest request);
        ShotBookmarkDeleteResponse Delete(int id, BookmarksDeleteRequest request);
    }
}