using System;
using System.Diagnostics;


namespace BasicEventLogging
{
    class Program
    {
        static void Main(string[] args)
        {

            string sourceName = "BasicEventLogging";
            string logName = sourceName + "Log";


            if (!EventLog.SourceExists(sourceName))
                //Create source and log. Note! PC has to be rebooted if source is redefined to an other log
                EventLog.CreateEventSource(sourceName, logName); 


            EventLog.WriteEntry(sourceName, "New message 1 (type is information as default)" );
            EventLog.WriteEntry(sourceName, "Error message", EventLogEntryType.Error);
            EventLog.WriteEntry(sourceName, "Waring message", EventLogEntryType.Warning);
            EventLog.WriteEntry(sourceName, "Information message", EventLogEntryType.Information);
            EventLog.WriteEntry(sourceName, "Message with event id and category", EventLogEntryType.Information, 10, 1);
        }
    }

    
}
