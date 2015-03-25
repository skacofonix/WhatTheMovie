using WTM.Domain;

namespace WTM.Mobile.Core
{
    public interface IContext
    {
        User CurrentUser { get; set; }
    }
}