using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MultithreadingDemo.Program;

namespace MultithreadingDemo
{
    public class SynchronizationDemo
    {
        // Task 1
        public void First()
        {
            lock (this) // this refers to the current thread
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(2000);
                }
            }
        }
        static void Main(string[] args)
        {
            SynchronizationDemo first = new SynchronizationDemo();
            //create thread
            // allocate method ref to the ThreadStart delegate
            Thread t1 = new Thread(new ThreadStart(first.First));
            Thread t2 = new Thread(new ThreadStart(first.First));
            t1.Start();
            t2.Start();
        }
    }
}
