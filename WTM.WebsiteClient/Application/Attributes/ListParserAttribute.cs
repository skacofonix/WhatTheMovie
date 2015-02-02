namespace WTM.WebsiteClient.Application.Attributes
{
    public class ListParserAttribute : BaseParserAttribute
    {
        public ListParserAttribute(string xPathExpression, string regexPattern = null)
            : base(xPathExpression, regexPattern)
        { }
    }
}
