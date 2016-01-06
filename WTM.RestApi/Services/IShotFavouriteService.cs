using WTM.RestApi.Controllers;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotFavouriteService
    {
        ShotFavouritesAddResponse Add(int id, string token);
        ShotFavouritesDeleteResponse Delete(int id, string token);
        ShotFavouritesResponse Get(string token, int? start, int? limit);
    }
}