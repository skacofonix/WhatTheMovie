namespace WTM.Api2.Services
{
    public interface IShotTagService
    {
        bool Add(string tag, string token);
        bool Delete(string tag, string token);
    }
}