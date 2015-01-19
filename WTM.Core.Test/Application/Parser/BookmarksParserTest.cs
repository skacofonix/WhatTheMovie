using System.Linq;
using NFluent;
using NUnit.Framework;
using WTM.Core.Application;
using WTM.Core.Application.Parsers;

namespace WTM.Core.Test.Application.Parser
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
    }
}
