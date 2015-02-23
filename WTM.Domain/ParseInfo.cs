using System;

namespace WTM.Domain
{
    public class ParseInfo
    {
        public string PropertyName { get; private set; }
        public ParseLevel Level { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }

        public ParseInfo(ParseLevel level, string message)
        {
            Level = level;
            Message = message;
        }

        public ParseInfo(string propertyName, ParseLevel level, string message)
        {
            PropertyName = propertyName;
            Level = level;
            Message = message;
        }

        public ParseInfo(ParseLevel level, string message, Exception exception)
        {
            Level = level;
            Message = message;
            Exception = exception;
        }

        public ParseInfo(string propertyName, ParseLevel level, string message, Exception exception)
        {
            PropertyName = propertyName;
            Level = level;
            Message = message;
            Exception = exception;
        }
    }
}