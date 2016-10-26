namespace Infrastructure.Logger
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Core.Interfaces;
    using log4net;
    using log4net.Config;

    public class Log4net : ILogger
    {
        private readonly ILog log;

        public Log4net()
        {
            var filepath = $"{AppDomain.CurrentDomain.BaseDirectory}log4net.config";
            var fileinfo = new FileInfo(filepath);

            XmlConfigurator.Configure(fileinfo);

            log = LogManager.GetLogger("Logger");
        }

        public void Debug(object message, Exception exception = null)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Debug(message);
                }
                else
                {
                    log.Debug(message, exception);
                }
            });
        }

        public void Info(object message, Exception exception = null)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Info(message);
                }
                else
                {
                    log.Info(message, exception);
                }
            });
        }

        public void Warn(object message, Exception exception = null)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Warn(message);
                }
                else
                {
                    log.Warn(message, exception);
                }
            });
        }

        public void Error(object message, Exception exception = null)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Error(message);
                }
                else
                {
                    log.Error(message, exception);
                }
            });
        }

        public void Fatal(object message, Exception exception = null)
        {
            Task.Factory.StartNew(() =>
            {
                if (exception == null)
                {
                    log.Fatal(message);
                }
                else
                {
                    log.Fatal(message, exception);
                }
            });
        }
    }
}
