using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sample44
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
                token.ThrowIfCancellationRequested();
            }, token).ContinueWith((t)=>
            {
                //t.Exception.Handle((e) => false);
                Console.WriteLine("You have canceled the task");
            },  TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine("Press enter to stop the ask");
            cancellationTokenSource.Cancel();
            Console.ReadLine();
            task.Wait();

            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }
    }
}
