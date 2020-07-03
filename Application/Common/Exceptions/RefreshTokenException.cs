using System;

namespace Application.Common.Exceptions
{
    public class RefreshTokenException : Exception
    {
        public RefreshTokenException(string error)
        : base(error)
        { }
    }
}