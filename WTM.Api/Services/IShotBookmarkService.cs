using WTM.Api.Models;

namespace WTM.Api.Services
{
    public interface IShotBookmarkService
    {
        ShotBookmarkResponse Get(BookmarksGetRequest request);
        ShotBookmarkAddResponse Add(int id, BookmarksAddRequest request);
        ShotBookmarkDeleteResponse Delete(int id, BookmarksDeleteRequest request);
    }
}