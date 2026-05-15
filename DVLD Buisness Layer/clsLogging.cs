using System;
using System.Diagnostics;
using DVLD_DataAccess_Layer;

namespace DVLD_Buisness_Layer
{
    public class clsLogging
    {
        public static void LogException(string LogMessage, EventLogEntryType eventLogEntryType)
        {
            clsLoggingData.LogException(LogMessage, eventLogEntryType);
        }
    }
}
