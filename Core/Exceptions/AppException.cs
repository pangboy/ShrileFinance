namespace Core.Exceptions
{
    using System;

    public class AppException : Exception
    {
        public AppException(string message = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
