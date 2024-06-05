using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MultithreadingDemo.Program;

namespace MultithreadingDemo
{
    public class MonitorClass
    {
        // Task 1
        public void First()
        {
            Monitor.Enter(this);// apply lock
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(2000);
                // send notification to thread which is in queue
                if (true)
                {
                    Monitor.PulseAll(this);
                    Monitor.Exit(this);
                }
            }
            Monitor.Exit(this);// release lock
            lock (this)
            {
                if (true)
                {
                }
            }
        }
        static void Main(string[] args)
        {
            ThreadDemo first = new ThreadDemo();
            //create thread
            // allocate method ref to the ThreadStart delegate
            Thread t1 = new Thread(new ThreadStart(first.First));
            Thread t2 = new Thread(new ThreadStart(first.First));
            t1.Start();
            t2.Start();
        }

    }
}
