using System;
using System.Threading;

namespace Volatile
{
    class Worker
    {
        // Keyword volatile is used as a hint to the compiler that this data member is accessed by multiple threads.
        private volatile bool _shouldStop;

        // This method is called when the thread is started.
        public void DoWork()
        {
            Console.WriteLine("Worker thread:\tStarted");
            bool work = false;
            Console.WriteLine($"Worker thread:\tBefore while {WorkerThreadExample.GetTime}");
            while (!_shouldStop)
            {
                work = !work; // simulate some work
            }
            Console.WriteLine($"Worker thread:\tAfter while  {WorkerThreadExample.GetTime}");
            Console.WriteLine("Worker thread:\tTerminating gracefully.");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }
    }

    public class WorkerThreadExample
    {
        public static string GetTime => $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{ DateTime.Now.Second}:{ DateTime.Now.Millisecond } sec";

        public static void Main()
        {
            Console.WriteLine("\n \n \nMain thread:\tMain");
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            Console.WriteLine("Main thread:\tStarting worker thread...");
            
            Console.WriteLine($"Worker thread:\tIsAlive {workerThread.IsAlive} ");
            workerThread.Start();
            Console.WriteLine($"Worker thread:\tIsAlive {workerThread.IsAlive} "); // становится true после .Start
            
            // Loop until the worker thread activates.
            Console.WriteLine($"Main thread:\tWaiting for worker thread... ");
            Console.WriteLine($"Main thread:\tBefore while {GetTime}");

            while (!workerThread.IsAlive)
                ;
            Console.WriteLine($"Main thread:\tAfter while {GetTime}");
            Console.WriteLine($"Worker thread:\tIsAlive {workerThread.IsAlive} ");
            // Put the main thread to sleep for 500 milliseconds to allow the worker thread to do some work.
            Console.WriteLine($"Main thread:\tSleep {GetTime}");
            Thread.Sleep(2000);

            // Request that the worker thread stop itself.
            workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread until the object's thread terminates.
            Console.WriteLine($"Worker thread:\tJoin {GetTime}");
            workerThread.Join();
            Console.WriteLine($"Worker thread:\tIsAlive {workerThread.IsAlive} ");
            Console.WriteLine($"Main thread:\tWorker thread has terminated  {GetTime}");

            Console.ReadLine();

            var a1 = Thread.GetCurrentProcessorId();
            var a2 = Thread.GetDomainID();
            var a3 = workerThread.ManagedThreadId;

            // почему у класса Thread часть методов статические, часть - экземплярные?
        }

        // Sample output:
        // Main thread: starting worker thread...
        // Worker thread: terminating gracefully.
        // Main thread: worker thread has terminated.
    }
}