using System;

namespace Application.Common.Exceptions
{
    public class SubscriptionException : Exception
    {
        public SubscriptionException(string error)
            : base(error)
        { }
    }
}