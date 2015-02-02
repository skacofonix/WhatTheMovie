namespace WTM.WebsiteClient.Application.Attributes
{
    public class StringParserAttribute : BaseParserAttribute
    {
        public StringParserAttribute(string xPathExpression, string regexFirstGroupPattern = null)
            : base(xPathExpression, regexFirstGroupPattern)
        { }
    }
}
