﻿using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.Core.Domain.WebsiteEntities;
using WTM.Core.Services;

namespace WTM.Core.Test.Services
{
    [TestFixture]
    public class ShotNewSubmissionsServiceTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private ShotNewSubmissionsService shotNewSubmissionsService;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            shotNewSubmissionsService = new ShotNewSubmissionsService(webClient, htmlParser);
        }

        [Test]
        public void WhenParseNewSubmissionsThenReturnOverviewShotCollection()
        {
            var overviewShotCollection = shotNewSubmissionsService.GetShots();
            Check.That(overviewShotCollection).IsNotNull();
            Check.That(overviewShotCollection.OverviewShotType).Equals(OverviewShotType.NewSubmissions);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
        }
    }
}
