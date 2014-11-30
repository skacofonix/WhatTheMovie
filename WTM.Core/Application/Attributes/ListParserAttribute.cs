namespace WTM.Core.Application.Attributes
{
    public class ListParserAttribute : BaseParserAttribute
    {
        public ListParserAttribute(string xPathExpression, string regexPattern = null)
            : base(xPathExpression, regexPattern)
        { }
    }
}
