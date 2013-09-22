using System;

namespace WorkReportReminder.Common.Logger
{
    public static class Log
    {
        private static ILogger m_instance;

        public static void Initialise(ILogger logger)
        {
            if(m_instance == null)
            {
                m_instance = logger;
            }
        }

        public static ILogger Instance
        {
            get
            {
                if(m_instance == null)
                {
                    throw new InvalidOperationException("Logger has not been initialiset yet.");
                }

                return m_instance;
            }
        }
    }
}
