using Example3_ThreadAdv;
using System;
using System.Threading;
namespace Example2_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadWithState thstate = new ThreadWithState("Welcome to Thread Class", 100, new ExampleCallback(ResultCallback));
            Thread th = new Thread(new ThreadStart(thstate.Threadproc));
            th.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            th.Join(); //Block till main thread Ends
            Console.WriteLine(
                "Independent task has completed; main thread ends.");
        }
        // The callback method must match the signature of the
        // callback delegate.
        //
        public static void ResultCallback(int lineCount)
        {
            Console.WriteLine(
                "Independent task printed {0} lines.", lineCount);
        }
    }
}
