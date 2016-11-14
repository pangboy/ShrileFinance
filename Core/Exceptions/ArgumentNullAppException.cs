namespace Core.Exceptions
{
    using System;

    public class ArgumentNullAppException : AppException
    {
        public ArgumentNullAppException(string message = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
