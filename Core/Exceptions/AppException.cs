namespace Core.Exceptions
{
    using System;

    /// <summary>
    /// 应用异常
    /// </summary>
    public class AppException : Exception
    {
        public AppException(string message = null, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
