namespace Core.Exceptions
{
    using System;

    public class InvalidOperationAppException : AppException
    {
        public InvalidOperationAppException(string message = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
