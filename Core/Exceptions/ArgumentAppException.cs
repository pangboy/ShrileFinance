namespace Core.Exceptions
{
    using System;

    /// <summary>
    /// 参数异常
    /// </summary>
    public class ArgumentAppException : AppException
    {
        private string paramName;

        public ArgumentAppException(string message = null, string paramName = null, Exception innerException = null) : base(message, innerException)
        {
            this.paramName = paramName;
        }

        public override string Message
        {
            get
            {
                var s = base.Message;
                if (!string.IsNullOrEmpty(paramName))
                {
                    return s + string.Format("\n参数名: {0}", paramName);
                }
                else
                {
                    return s;
                }
            }
        }

        public virtual string ParamName
        {
            get { return paramName; }
        }
    }
}
