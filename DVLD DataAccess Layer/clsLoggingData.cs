using System;
using System.Diagnostics;

namespace DVLD_DataAccess_Layer
{
    public class clsLoggingData
    {
        public static void LogException(string LogMessage, EventLogEntryType eventLogEntryType)
        {
            string SourceName = "DVLD App";

            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            EventLog.WriteEntry(SourceName, LogMessage, eventLogEntryType);
        }
    }
}
