using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace sample48
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.TraceInformation("Tracing application...");
            traceSource.TraceEvent(TraceEventType.Warning, 1, "My Warning Message");

            traceSource.Flush();
            traceSource.Close();
        }
    }
}
