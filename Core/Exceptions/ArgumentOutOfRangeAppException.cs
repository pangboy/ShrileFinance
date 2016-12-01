namespace Core.Exceptions
{
    using System;

    /// <summary>
    /// 当参数值超出调用的方法所定义的允许取值范围时引发的异常
    /// </summary>
    public class ArgumentOutOfRangeAppException : ArgumentAppException
    {
        public ArgumentOutOfRangeAppException(string paramName = null, string message = null, Exception innerException = null) : base(message, paramName, innerException)
        {
        }
    }
}
