using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
namespace Example1_Process
{
    class Program
    {
        static void Main(string[] args)
        {
            //int pid = 0;
            Console.WriteLine("Hello World!");
            ListofRunningProcess();
            Console.WriteLine("Enter the PID for which you need detail");
            string pidstr = Console.ReadLine();
            GetSpecificProcess(int.Parse(pidstr));
        }

        /// <summary>
        /// Get all processes running on the local computer.
        /// </summary>
        private static void ListofRunningProcess()
        {


            //var runningProcess = Process.GetProcesses();

            //Sort the PRocess by ID
            var runningProcess = from proc in Process.GetProcesses() orderby proc.Id select proc;
            foreach (var rp in runningProcess)
            {
                string info = string.Format("->:{0}\tName:{1}", rp.Id, rp.ProcessName);
                Console.WriteLine(info);
            }
        }
        /// <summary>
        /// Investigating a specific process
        /// </summary>
        private static void GetSpecificProcess(int pid)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(pid);
                //*********************************
                // List of thread used by a Process
                //*********************************
                Console.WriteLine("\n Below is list of thread used by Process {0}", proc.ProcessName);
                ProcessThreadCollection theThread = proc.Threads;
                foreach (ProcessThread pt in theThread)
                {
                    string info = string.Format("-> ThreadID:{0}\t StartTime:{1} \t Priority:{2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                    Console.WriteLine(info);
                }

                //******************************
                //Investigate list of Module loaded by a Process
                //******************************
                Console.WriteLine("\n******Below is list of Modules used by Process {0}***********", proc.ProcessName);
                ProcessModuleCollection loadedmodule = proc.Modules;
                foreach (ProcessModule lm in loadedmodule)
                {
                    string moduleinfo = string.Format("-> ModuleName:{0}", lm.ModuleName);
                    Console.WriteLine(moduleinfo);
                }
            }
            catch (ArgumentException arex)
            {
                Console.WriteLine(arex.Message);
            }
        }
        /// <summary>
        /// Enum thread for 
        /// </summary>
        /// <param name="pID"></param>
        private static void EnumThreadForPID(int pID)
        {

        }
    }
}
