using WTM.Api.Models;

namespace WTM.Api.Services
{
    public interface IShotTagService
    {
        ShotTagAddResponse Add(int id, TagsAddRequest request);
        ShotTagDeleteResponse Delete(int id, TagsDeleteRequest request);
    }
}