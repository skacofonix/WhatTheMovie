﻿using NFluent;
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

            var authentifier = new Authentifier(webClient, htmlParser);
            if(authentifier.Login("captainOblivious", "captainOblivious"))
                webClient.SetCookie(authentifier.CookieSession);
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
            settings.ShowGore = false;
            settings.ShowNudity = true;
            Check.That(settingsService.Write(settings)).IsTrue();
        }

        [Test]
        public void WhenInverseBoolParametersThenSettingsChange()
        {
            var initialSettings = settingsService.Read();

            var inverseSettings = new Settings
            {
                ShowGore = !initialSettings.ShowGore,
                ShowNudity = !initialSettings.ShowNudity
            };

            settingsService.Write(inverseSettings);

            var finalSettings = settingsService.Read();

            Check.That(initialSettings.ShowGore.GetValueOrDefault(false)).IsNotEqualTo(finalSettings.ShowGore.GetValueOrDefault(false));
            Check.That(initialSettings.ShowNudity.GetValueOrDefault(false)).IsNotEqualTo(finalSettings.ShowNudity.GetValueOrDefault(false));
        }
    }
}
