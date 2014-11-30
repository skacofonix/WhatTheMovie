using System;
using System.Globalization;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Parsers
{
    internal class FeatureFilmParser : ParserBase<FeatureFilm>
    {
        public override string Identifier { get { return "overview"; } }

        public FeatureFilmParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        const string DateFormat = "yyyy/MM/dd";

        protected override FeatureFilm Parse(string parameter)
        {
            DateTime date;
            if (parameter != null && DateTime.TryParseExact(parameter, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return Parse(date);
            return base.Parse(null);
        }

        public FeatureFilm Parse(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            return Parse(date);
        }

        private FeatureFilm Parse(DateTime date)
        {
            var stringDate = date.ToString(DateFormat);
            return base.Parse(stringDate);
        }
    }
}
