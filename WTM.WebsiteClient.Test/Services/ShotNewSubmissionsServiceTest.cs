﻿using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Domain;
using WTM.WebsiteClient.Services;

namespace WTM.WebsiteClient.Test.Services
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
            // Damnit, WTF ?
            Check.That(overviewShotCollection.ShotType).IsNotNull();
            Check.That(overviewShotCollection.ShotType).Equals(ShotType.NewSubmissions);
            Check.That(overviewShotCollection.Shots).IsNotNull();
            Check.That(overviewShotCollection.Shots.Any()).IsTrue();
        }
    }
}
