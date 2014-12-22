using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.Core.Domain.WebsiteEntities;
using WTM.Core.Services;

namespace WTM.Core.Test.Services
{
    [TestFixture]
    public class SettingsServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private SettingsService settingsService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            settingsService = new SettingsService(webClient, htmlParser);
        }

        [Test]
        public void WhenReadSettingsThenReturnInstance()
        {
            Check.That(settingsService.Read()).IsNotNull();
        }

        [Test]
        public void WhenWriteSettingsThenReturnTrue()
        {
            var settings = new Settings();
            Check.That(settingsService.Write(settings)).IsTrue();
        }
    }
}
