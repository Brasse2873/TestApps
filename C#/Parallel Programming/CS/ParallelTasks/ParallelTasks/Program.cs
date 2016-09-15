using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParallelTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners[0].TraceOutputOptions = TraceOptions.Timestamp|TraceOptions.DateTime|TraceOptions.ThreadId;
            Trace.Listeners.Add(new ConsoleTraceListener() { TraceOutputOptions = TraceOptions.DateTime });

            //Use tasks explicitly
            Task t1 = Task.Factory.StartNew(() => Method1(1));
            Task t2 = Task.Factory.StartNew(() => Method2(2));
            Task.WaitAll(t1,t2);
            Trace.TraceInformation("Tasks explicitly: All Tasks done");

            //Use Parallel.Invoke
            Parallel.Invoke( ()=> Method1(3), ()=> Method2(4) );
            Trace.TraceInformation("Parallel.Invoke: All Tasks done");
        }

        static void Method1(int par1)
        {
            Trace.TraceInformation("Method1:{0}", par1);
            Thread.Sleep(1000);
        }

        static void Method2(int par1)
        {
            Trace.TraceInformation("Method2:{0}", par1);
            Thread.Sleep(1000);
        }
    }
}
