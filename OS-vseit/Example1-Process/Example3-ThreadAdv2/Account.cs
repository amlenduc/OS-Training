using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Example3_ThreadAdv2
{
    class Account
    {
        int balance;
        Object samplelock = new Object();
        public Account(int initbalance)
        {
            balance = initbalance;
        }
       public int withdraw(int amount)
        {
            if (balance<0)
            {
                throw new Exception("Not enough balance");
            }
            Monitor.Enter(samplelock);
            try
            {
                if (balance>=amount)
                {
                    Console.WriteLine("Amount Withdrawan:" + amount);
                    balance = balance - amount;
                    return balance;
                }
            }
            catch
            {
                Monitor.Exit(samplelock);
            }
            return 0;
        }

        public int randomwithdraw()
        {
            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                var balance = withdraw(rand.Next(2000, 5000));
                if (balance > 0)
                {
                    Console.WriteLine("Balance left" + balance);
                }
            }

            return balance;
        }
    }
}
