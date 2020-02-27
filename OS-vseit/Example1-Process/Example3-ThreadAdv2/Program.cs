using System;
using System.Threading.Tasks;

namespace Example3_ThreadAdv2
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(20000);
            Task task1 = Task.Factory.StartNew(() => account.randomwithdraw());
            Task task2 = Task.Factory.StartNew(() => account.randomwithdraw());
            Task task3 = Task.Factory.StartNew(() => account.randomwithdraw());
            Task.WaitAll(task1, task2, task3);
            Console.WriteLine("All Task completed");
        }
    }
}
