namespace Core.Exceptions
{
    using System;

    class ArgumentOutOfRangeAppException : AppException
    {
        public ArgumentOutOfRangeAppException(string message = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
