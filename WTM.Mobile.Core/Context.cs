using WTM.Domain;

namespace WTM.Mobile.Core
{
    public class Context : IContext
    {
        public User User { get; set; }
        public string UserToken { get; set; }
        public string UserName { get; set; }
    }
}