using System;
using System.Collections.Generic;
using System.Linq;
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

        public BookmarkCollection GetFirst30Bookmarks()
        {
            return base.Parse();
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
            }
        }
    }
}
