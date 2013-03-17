using System;
using System.Diagnostics;
using System.IO;
using log4net;
using log4net.Config;

namespace WorkReportReminder.Common
{
    internal class Logger : ILogger
    {
        private const int DETAILED_INFO_LEVEL = 3;
        private const string DEFAULT_FILE_NAME = "Lib/log4net.config";
        private ILog m_logger;
        private bool m_isDetailedInfoEnabled;

        public Logger()
        {
            var configFile = new FileInfo(DEFAULT_FILE_NAME);
            XmlConfigurator.Configure(configFile);
            m_logger = LogManager.GetLogger(ApplicationInfo.Name);
        }

        /// <summary>
        /// Configure logger using values from config file.
        /// </summary>
        public void Configure(bool detailedInfoEnabled)
        {
            m_isDetailedInfoEnabled = detailedInfoEnabled;
        }

        /// <summary>
        /// Returns detailed info about place of code where logger was called.
        /// Detailed info contains class and method name.
        /// </summary>
        private string DetailedInfo
        {
            get
            {
                var stackTrace = new StackTrace();
                var className = stackTrace.GetFrame(DETAILED_INFO_LEVEL).GetMethod().ReflectedType.Name;
                var methodName = stackTrace.GetFrame(DETAILED_INFO_LEVEL).GetMethod().Name;
                return string.Format("{0}.{1}: ", className, methodName);
            }
        }

        /// <summary>
        /// Formats and returns data written to log file.
        /// Depending on configuration it can also returns detailed information about place of code from where logger was called
        /// </summary>
        private string FormatOutputData(string message)
        {
            if (m_isDetailedInfoEnabled)
            {
                return DetailedInfo + message;
            }

            return message;
        }

        /// <summary>
        /// Formats and returns whole call stact with specified message at the end;
        /// </summary>
        private string FormatOutputDataWithCallStack(string message)
        {
            string CALL_STACK = "Call Stack:";
            char NEW_LINE = '\n';

            var st = new StackTrace(DETAILED_INFO_LEVEL, false);
            var callStack = st.GetFrames();
            
            string callStackOutput = message + NEW_LINE + CALL_STACK + NEW_LINE;

            foreach (var frame in callStack)
            {
                callStackOutput += frame.GetMethod().ReflectedType.Name + "." + frame.GetMethod().Name + NEW_LINE;
            }

            return callStackOutput;
        }

        public void Debug(string message)
        {
            if (m_logger.IsDebugEnabled)
            {
                m_logger.Debug(FormatOutputData(message));
            }
        }

        public void Info(string message)
        {
            if (m_logger.IsInfoEnabled)
            {
                m_logger.Info(FormatOutputData(message));
            }
        }

        public void Warning(string message)
        {
            if (m_logger.IsWarnEnabled)
            {
                m_logger.Warn(FormatOutputData(message));
            }
        }

        public void Error(string message)
        {
            if (m_logger.IsErrorEnabled)
            {
                m_logger.Error(FormatOutputData(message));
            }
        }

        public void Fatal(string message)
        {
            if (m_logger.IsFatalEnabled)
            {
                m_logger.Fatal(FormatOutputDataWithCallStack(message));
            }
        }
    }
}
