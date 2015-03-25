using WTM.Domain;

namespace WTM.Mobile.Core
{
    public class Context : IContext
    {
        public User CurrentUser { get; set; }
    }
}