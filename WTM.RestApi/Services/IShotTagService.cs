using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotTagService
    {
        ShotTagAddResponse Add(int id, TagsAddRequest request);
        ShotTagDeleteResponse Delete(int id, TagsDeleteRequest request);
    }
}