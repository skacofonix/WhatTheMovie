using WTM.Api.Models;

namespace WTM.Api.Services
{
    public interface IShotFavouriteService
    {
        ShotFavouritesResponse Get(FavouritesGetRequest request);
        ShotFavouritesAddResponse Add(int id, FavouritesAddRequest request);
        ShotFavouritesDeleteResponse Delete(int id, FavouritesDeleteRequest request);
    }
}