using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Log to default listener = Output window
            Debug.WriteLine("Main starts");

            for (int ix = 0; ix < 100; ++ix)
            {
                Console.WriteLine("ix={0}",ix);
            }

            //Log to file
            //-----------
            TextWriterTraceListener logListener = new TextWriterTraceListener("DebugTest.Log");
            Debug.Listeners.Add(logListener);
            Debug.WriteLine("Testline 1");


            //An other way to log to file
            FileStream logFile = new FileStream("DebugTest2.log", FileMode.OpenOrCreate );
            TextWriterTraceListener logListener2 = new TextWriterTraceListener( logFile );
            Debug.Listeners.Add(logListener2);
            Debug.WriteLine("Testline 2");

            //Stop log to file
            Debug.Flush();
            Debug.Listeners.Remove(logListener2);
            Debug.WriteLine("Testline 3");

            //Log to event log
            if (!EventLog.SourceExists("DebugDemo"))
                EventLog.CreateEventSource("DebugDemo", "DebugDemoLog");

            EventLog eventLog = new EventLog("DebugDemoLog",".","DebugDemo");
            EventLogTraceListener eventListener = new EventLogTraceListener(eventLog);
            Debug.Listeners.Add(eventListener);
            Debug.WriteLine("Testline 4");


            Debug.WriteLine("Main ends");
            Debug.Flush();
        }
    }
}
