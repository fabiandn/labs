using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample51
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog applicationLog = new EventLog("Application", ".", "testEvnetLogEvent");
            applicationLog.EntryWritten += (sender, e) =>
            {
                Console.WriteLine(e.Entry.Message);
            };

            applicationLog.EnableRaisingEvents = true;
            applicationLog.WriteEntry("Test Message", EventLogEntryType.Information);

            Console.ReadKey();
        }
    }
}
