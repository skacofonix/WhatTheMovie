using WTM.Domain;

namespace WTM.Mobile.Core
{
    public interface IContext
    {
        User User { get; set; }
        string UserToken { get; set; }
        string UserName { get; set; }
    }
}