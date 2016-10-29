using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace sample49
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            EventLog myEventLog = new EventLog();
            myEventLog.Source = "MySource";
            myEventLog.WriteEntry("Log Event!");

            EventLog log = new EventLog("MyNewLog");
            Console.WriteLine($"Total Entries : {log.Entries.Count}");
            EventLogEntry last = log.Entries[log.Entries.Count - 1];
            Console.WriteLine($"Index: {last.Index}");
            Console.WriteLine($"Source: {last.Source}");
            Console.WriteLine($"Type: {last.EntryType}");
            Console.WriteLine($"Time: {last.TimeWritten}");
            Console.WriteLine($"Message: {last.Message}");

            Console.ReadKey();
        }
    }
}
