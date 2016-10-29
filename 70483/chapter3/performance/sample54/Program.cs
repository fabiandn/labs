using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace sample54
{
    class Program
    {
        static void Main(string[] args)
        {
            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Created performance counters");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            var totalOperationCounter = new PerformanceCounter("MyCategory",
                "# operations executed",
                "",
                false);

            var operationsPerSecondCounter = new PerformanceCounter("MyCategory",
                "# operations / sec",
                "",
                false);

            totalOperationCounter.Increment();
            operationsPerSecondCounter.Increment();

        }

        private static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection
                {
                    new CounterCreationData("# operations excecuted",
                    "Total number of operations executed",
                    PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData("# operations / sec",
                    "Number of operations executed per second",
                    PerformanceCounterType.RateOfCountsPerSecond32)
                };

                PerformanceCounterCategory.Create("MyCategory", "Sample category for Codeproject", PerformanceCounterCategoryType.Unknown, counters);

                return true;
            }

            return false;
        }
    }
}
