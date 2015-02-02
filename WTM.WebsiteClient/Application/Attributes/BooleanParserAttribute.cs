namespace WTM.WebsiteClient.Application.Attributes
{
    public class BooleanParserAttribute : BaseParserAttribute
    {
        public bool Reverse { get; private set; }

        public BooleanParserAttribute(string xPathExpression, string regexIsMatchPattern = null, bool reverse = false)
            : base(xPathExpression, regexIsMatchPattern)
        {
            Reverse = reverse;
        }
    }
}
