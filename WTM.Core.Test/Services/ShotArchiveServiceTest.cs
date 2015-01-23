﻿using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Domain;
using WTM.WebsiteClient.Services;

namespace WTM.WebsiteClient.Test.Services
{
    [TestFixture]
    public class ShotArchiveServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private ShotArchiveService shotArchiveService;
        private IServerDateTime serverDateTime;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            shotArchiveService = new ShotArchiveService(webClient, htmlParser);
            serverDateTime = new ServerDateTime();
        }

        [Test]
        public void WhenParseTheArchiveThenReturnOverviewShotCollection()
        {
            var overviewShotCollection = shotArchiveService.GetArhciveOneMonthOld();
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.OverviewShotType).Equals(OverviewShotType.Archive);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
        }
    }
}