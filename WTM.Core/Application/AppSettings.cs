using WTM.Core.Application;

namespace WTM.WebsiteClient.Application
{
    public class AppSettings : IAppSettings
    {
        public string Proxy { get; set; }

        public string UserAgent { get; set; }

        public AppSettings()
        {
            Proxy = Properties.Settings.Default.Proxy;
            UserAgent = Properties.Settings.Default.UserAgent;
        }
    }
}