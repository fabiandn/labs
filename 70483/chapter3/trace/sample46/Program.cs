using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace sample46
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceSource trace = new TraceSource("myTraceSource", SourceLevels.All);

            trace.TraceInformation("Tracing application...");
            trace.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            trace.TraceData(TraceEventType.Information, 1, new object[] { "a", "b", "c" });
            trace.Flush();
            trace.Close();
        }
    }
}
