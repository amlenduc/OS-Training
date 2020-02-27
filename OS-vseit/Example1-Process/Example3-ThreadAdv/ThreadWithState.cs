using System;
using System.Collections.Generic;
using System.Text;

namespace Example3_ThreadAdv
{
    // The ThreadWithState class contains the information needed for
    // a task, the method that executes the task, and a delegate
    // to call when the task is complete.
    //
    class ThreadWithState
    {
        private ExampleCallback callbackfn;
        //State information
        private string Welcomemsg;
        private int numbervalue = 9999;

        public ThreadWithState(string text, int numbervalue, ExampleCallback callbackdelegate)
        {
            Welcomemsg = text;
            numbervalue = 100;
            callbackfn = callbackdelegate;
        }
        public void Threadproc()
        {
            Console.WriteLine(Welcomemsg, numbervalue);
            if (callbackfn != null)
                callbackfn(100);
        }
    }
    public delegate void ExampleCallback(int linecount);
}
