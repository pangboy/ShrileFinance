using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using log4net;
using log4net.Appender;
using log4net.Core;

namespace Web.Infrastructure
{
    public class Log4net
    {
        public static ILog Log
        {
            get { return LogManager.GetLogger("Logger"); }
        }
    }

    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            if (exception is Core.Exceptions.AppException)
            {
                context.Response = context.Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, exception.Message);
            }


            var parameters = new Dictionary<String, Object>();

            // 添加路由参数
            if (context.ActionContext.RequestContext.RouteData.Values.ContainsKey("id"))
            {
                parameters.Add("id", context.ActionContext.RequestContext.RouteData.Values["id"]);
            }

            // 添加请求参数
            var request = HttpContext.Current.Request;
            var queryParams =
                request.QueryString.Count > 0 ? request.QueryString : request.Form;

            foreach (var key in queryParams.AllKeys)
            {
                parameters.Add(key, queryParams[key]);
            }

            // 将参数加入到异常数据中
            foreach (var item in parameters)
            {
                exception.Data.Add(item.Key, item.Value);
            }

            // 记录日志
            Log4net.Log.Error("Global", exception);

            LogManager.GetLogger("Logger").Error("Global", new Exception("程序开始运行"));
        }
    }

    public class YWAppender : AppenderSkeleton
    {
        public bool Enabled { get; set; }

        public string Url { get; set; }

        public string AppKey { get; set; }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (Enabled)
            {
                string message = GetMessage(loggingEvent);
                string category = String.Empty;

                switch (loggingEvent.Level.Name)
                {
                    case "INFO":
                        category = "LOG";
                        break;
                    case "WARN":
                        category = "INFO";
                        break;
                    case "ERROR":
                    case "FATAL":
                        category = "ERROR";
                        break;
                    default:
                        break;
                }

                if (category != String.Empty)
                {
                    var send = Send(message, category);
                }
            }
        }

        protected string GetMessage(LoggingEvent loggingEvent)
        {
            var sb = new System.Text.StringBuilder();

            // 信息
            const string SORT_FORMAT = "{0,-8}: {1}\r\n";
            sb.AppendFormat(SORT_FORMAT, "Messages", loggingEvent.MessageObject);
            sb.AppendFormat(SORT_FORMAT, "Level", loggingEvent.Level.Name);
            sb.AppendFormat(SORT_FORMAT, "Date", loggingEvent.TimeStamp);
            sb.AppendFormat(SORT_FORMAT, "User", loggingEvent.Identity);
            sb.AppendLine();

            var exception = loggingEvent.ExceptionObject;
            if (exception != null)
            {
                // 异常
                sb.AppendLine("Exception:");
                sb.AppendFormat("   {0}", exception.Message);
                sb.AppendLine();
                sb.AppendLine();

                // 参数
                var parameters = exception.Data;

                sb.AppendLine("Parameters:");
                foreach (var key in parameters.Keys)
                {
                    sb.AppendFormat("   {0} : {1}", key, parameters[key]);
                    sb.AppendLine();
                }

                sb.AppendLine();

                // 堆栈
                sb.AppendLine("StackTraces:");
                var stackTraces = exception.StackTrace.Split(new String[] { "\r\n" }, StringSplitOptions.None).Where(m =>
                    !m.Contains("在 System.") &&
                    !m.Contains("引发异常的上一位置中堆栈跟踪的末尾"));
                sb.AppendLine(String.Join("\r\n", stackTraces));
                sb.AppendLine();
            }

            return sb.ToString();
        }

        protected async Task Send(string message, string level)
        {
            HttpClient client = new HttpClient();

            var param = new Dictionary<string, string>();
            param.Add("content", message);
            param.Add("appKey", AppKey);
            param.Add("category", level);

            var response = await client.PostAsync(Url, new FormUrlEncodedContent(param));
        }
    }
}