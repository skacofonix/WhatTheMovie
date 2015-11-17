using System;

namespace WTM.Domain.OldSchool
{
    public class ParseErrorsChangedEventArgs : EventArgs
    {
        public ParseErrorsChangedEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; private set; }
    }
}