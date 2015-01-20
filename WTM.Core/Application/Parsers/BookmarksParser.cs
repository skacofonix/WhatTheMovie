using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Parsers
{
    internal class BookmarksParser : ParserBase<BookmarkCollection>
    {
        public override string Identifier { get { return "mybookmarks"; } }

        public BookmarksParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public bool OrderBookmarksNewestToOlder
        {
            get { return orderBookmarksNewestToOlder; }
            set
            {
                if (orderBookmarksNewestToOlder != value)
                {
                    orderBookmarksNewestToOlder = value;
                    ChangeOrderOfBookmarks(orderBookmarksNewestToOlder);
                }
            }
        }
        private bool orderBookmarksNewestToOlder;


        public BookmarkCollection GetFirst30Bookmarks()
        {
            return base.Parse();
        }

        public BookmarkCollection GetBookmarksByPage(int page)
        {
            var uri = new Uri(MakeUri(), "?page=" + page);
            return base.Parse(uri);
        }

        private bool ChangeOrderOfBookmarks(bool isOrderNewestToOlder)
        {
            var uri = new Uri(WebClient.UriBase, "/user/set");
            var requestBuilder = new HttpRequestBuilder();
            requestBuilder.AddParameter("setting", "show_newest_bookmarks");
            requestBuilder.AddParameter("value", isOrderNewestToOlder ? "true" : "false");
            var data = requestBuilder.ToString();

            var httpWebResponse = WebClient.Post(uri, data) as HttpWebResponse;
            if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        protected override void ParseHtmlDocument(BookmarkCollection instance, HtmlDocument htmlDocument)
        {
            instance.Bookmarks = new List<Bookmark>();

            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null)
                return;

            var regexShotId = new Regex("http://whatthemovie.com/shot/(\\d*)");
            var regexNbDaysLeft = new Regex("(\\d*) days left");

            var bookmarkNode = navigator.Select("//div[@id='container']/div[@id='main_white']/div[@class='col_left nopadding']/div[@class='shot_focus_box thumbnails_only']/ul[@class='movie_small_preview clearfix']/div[@class='row']/ul[@class='movie_list clearfix']/li/div[@class='wrapper']/div");
            while (bookmarkNode.MoveNext())
            {
                var bookmark = new Bookmark();
                instance.Bookmarks.Add(bookmark);

                var shotNode = bookmarkNode.Current.SelectSingleNode("./a[1]/@href");
                if (shotNode != null)
                {
                    bookmark.ShotUrl = shotNode.InnerXml;

                    var shotMatch = regexShotId.Match(shotNode.InnerXml);
                    if (shotMatch.Success)
                    {
                        int shotIdTemp;
                        if (int.TryParse(shotMatch.Groups[1].Value, out shotIdTemp))
                            bookmark.ShotId = shotIdTemp;
                    }
                }

                var imageNode = bookmarkNode.Current.SelectSingleNode("./a[1]/img/@src");
                if (imageNode != null)
                    bookmark.ImageUrl = imageNode.InnerXml;

                var nbDaysLeftNode = bookmarkNode.Current.SelectSingleNode("./p");
                if (nbDaysLeftNode != null)
                {
                    if (nbDaysLeftNode.InnerXml.Contains("Solution is available"))
                    {
                        bookmark.SolutionAvailable = true;
                    }
                    else
                    {
                        bookmark.SolutionAvailable = false;
                        var nbDayMatch = regexNbDaysLeft.Match(nbDaysLeftNode.InnerXml);
                        if (nbDayMatch.Success)
                        {
                            int nbDaysLeftTemp;
                            if (int.TryParse(nbDayMatch.Groups[1].Value, out nbDaysLeftTemp))
                                bookmark.NbDaysLeft = nbDaysLeftTemp;
                        }
                    }
                }

                var regexNbPage = new Regex("/mybookmarks?page=(\\d*)");
                var nodeNbPage = navigator.Select("//div[@class='black_pagination']/a");
                int totalPageNumber = 1;
                while (nodeNbPage.MoveNext())
                {
                    int pageNumber;
                    if (int.TryParse(nodeNbPage.Current.InnerXml, out pageNumber))
                        if (pageNumber > totalPageNumber)
                            totalPageNumber = pageNumber;
                }
                instance.NumberOfPage = totalPageNumber;
            }
        }
    }
}
