using System;

namespace FindMyItem.Common.Exceptions
{
    public class HtmlObjectNotFoundException : Exception
    {
        public HtmlObjectNotFoundException(string message)
            : base(message)
        {

        }
    }
}
