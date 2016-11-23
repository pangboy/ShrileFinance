namespace Core.Exceptions
{
    using System;

    public class ArgumentAppException : AppException
    {
        public ArgumentAppException(string message = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
