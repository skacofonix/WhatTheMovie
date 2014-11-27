using System;
using System.Linq;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Parsers
{
    internal class MovieParser : ParserBase<Movie>
    {
        public override string Identifier { get { return "movies"; } }

        public MovieParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        protected override Movie Parse()
        {
            var movie = new Movie();

            var headerTitleSection = Document.GetElementbyId("main_white")
                                             .Descendants("div")
                                             .FirstOrDefault(d => d.Attributes.Any(attr => attr.Name == "class" && attr.Value == "header clearfix"));

            var titleSection = headerTitleSection.Descendants("h1")
                                                 .FirstOrDefault();

            var dateSection = titleSection.Descendants("span")
                                          .FirstOrDefault()
                                          .InnerText;

            movie.OriginalTitle = GetOriginalTitle();

            return movie;
        }

        private string GetOriginalTitle()
        {
            throw new NotImplementedException();
        }
    }
}
