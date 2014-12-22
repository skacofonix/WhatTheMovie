using System;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Services
{
    internal class SettingsService
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;
        private readonly SettingsParser settingsParser;

        public SettingsService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
            settingsParser = new SettingsParser(webClient, htmlParser);
        }

        public Settings Read()
        {
            return settingsParser.Parse();
        }

        public bool Write(Settings settings)
        {
            throw new NotImplementedException();
        }
    }
}
