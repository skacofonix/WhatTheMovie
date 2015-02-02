using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.WebsiteClient.Application;
using WTM.WebsiteClient.Application.Parsers;

namespace WTM.WebsiteClient.Test.Application.Parser
{
    [TestFixture]
    public class BookmarksParserTest
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        private BookmarksParser bookmarksParser;

        [SetUp]
        public void Init()
        {
            webClient = new WebClientWTM();
            htmlParser = new HtmlParser();
            bookmarksParser = new BookmarksParser(webClient, htmlParser);

            var authentifier = new Authentifier(webClient, htmlParser);
            if (authentifier.Login("captainOblivious", "captainOblivious"))
                webClient.SetCookie(authentifier.CookieSession);
        }

        [Test]
        public void WhenParseBookmarksThenReturnBookmars()
        {
            var bookmarks = bookmarksParser.GetFirst30Bookmarks();

            Check.That(bookmarks).IsNotNull();
            Check.That(bookmarks.Bookmarks).IsNotNull();
            Check.That(bookmarks.Bookmarks.Any()).IsTrue();
        }

        [Test]
        public void WhenSpecifyPageThenParseBookmars()
        {
            for (var i = 1; i <= 3; i++)
            {
                var bookmarks = bookmarksParser.GetBookmarksByPage(i);
                Check.That(bookmarks).IsNotNull();
                Check.That(bookmarks.Bookmarks).IsNotNull();
                Check.That(bookmarks.Bookmarks.Any()).IsTrue();
            }
        }

        [Test]
        public void WhenParseBookmarksThenCountNumberOfPage()
        {
            var bookmarks = bookmarksParser.GetFirst30Bookmarks();
            Check.That(bookmarks.NumberOfPage).IsGreaterThan(1);
        }

        [Test]
        public void WhenChangeOrderBookmargsThenOrderOfBookmarkChanged()
        {
            var bookmarks = bookmarksParser.GetFirst30Bookmarks().Bookmarks;

            Check.That(bookmarks.Count).IsGreaterThan(1);

            var firstBookmarkShotId = bookmarks.First().ShotId;

            bookmarksParser.OrderBookmarksNewestToOlder = true;

            var lastBookmarksShotId = bookmarksParser.GetFirst30Bookmarks().Bookmarks.First().ShotId;

            Check.That(firstBookmarkShotId).IsDistinctFrom(lastBookmarksShotId);

            bookmarksParser.OrderBookmarksNewestToOlder = false;

            var firstBookmarkShotIdAgain = bookmarksParser.GetFirst30Bookmarks().Bookmarks.First().ShotId;

            Check.That(firstBookmarkShotId).Equals(firstBookmarkShotIdAgain);
        }
    }
}