using System;
using System.Threading;
namespace Example2_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = Thread.CurrentThread;
            th.Name = "My Thread";
            Console.WriteLine("Thread Name is:{0}", Thread.CurrentThread.Name);

            //Thread th1 = new Thread(Method1)
            //{
            //    Name = "Thread1"
            //};
            Thread th1 = new Thread(new ThreadStart(Method1));
            Console.WriteLine("Statistic for thread1 - \nProiroty Level:{0} \t ThreadState:{1}", th1.Priority, th1.ThreadState);

            Thread th2 = new Thread(new ThreadStart(Method2));
            Console.WriteLine("Statistic for thread2 - \nProiroty Level:{0} \t ThreadState:{1}", th1.Priority, th1.ThreadState);

            Thread th3 = new Thread(new ThreadStart(Method3));
            Console.WriteLine("Statistic for thread3 - \nProiroty Level:{0} \t ThreadState:{1}", th1.Priority, th1.ThreadState);

            //Thread th2 = new Thread(Method2)
            //{
            //    Name = "Thread2"
            //};

            //Thread th3 = new Thread(Method3)
            //{
            //    Name = "Thread3"
            //};
            //Executing the methods
            th1.Start();
            th2.Start();
            th3.Start();
            Console.Read();
        }
        static void Method1()
        {
            Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
            //Show details of hosting AppDomain
            Console.WriteLine("Statistic for thread1 - \nAppdomain:{0} \t Proiroty Level:{1} \t ThreadState:{2}", Thread.GetDomain().FriendlyName, Thread.CurrentThread.Priority, Thread.CurrentThread.ThreadState);
            for (int i = 1; i <= 25; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
        }

        static void Method2()
        {
            Console.WriteLine("Method2 Started using " + Thread.CurrentThread.Name);
            Console.WriteLine("Statistic for thread2 - \nAppdomain:{0} \t Proiroty Level:{1} \t ThreadState:{2}", Thread.GetDomain().FriendlyName, Thread.CurrentThread.Priority, Thread.CurrentThread.ThreadState);
            for (int i = 1; i <= 25; i++)
            {
                Console.WriteLine("Method2 :" + i);
            }
        }
        static void Method3()
        {
            Console.WriteLine("Method3 Started using " + Thread.CurrentThread.Name);
            Console.WriteLine("Statistic for thread3 - \nAppdomain:{0} \t Proiroty Level:{1} \t ThreadState:{2}", Thread.GetDomain().FriendlyName, Thread.CurrentThread.Priority, Thread.CurrentThread.ThreadState);

            for (int i = 1; i <= 25; i++)
            {
                Console.WriteLine("Method3 :" + i);
            }
        }

    }
}
