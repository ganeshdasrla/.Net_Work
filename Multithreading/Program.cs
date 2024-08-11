using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class Program
    {
        void Main(string[] args)
        {
            Console.WriteLine("Cores count: " + Environment.ProcessorCount);

            //A thread needs an operation(method delegate) to be instantiated
            //Create new thread
            var thread = new Thread(new ThreadStart(Operation));


            var thread1 = new Thread(Operation);

            var thread2 = new Thread(() => { Operation(); });

            //Thread needs to be explicitly started
            thread.Start();

            //Pause and interrupt threads
            Thread.Sleep(2000);

            //Will interrupt the thread only if it is in blocked(in Join, Sleep state) state.
            thread.Interrupt();

            //Waits until the thread stops "gracefully"
            //Main thread will have to wait for the thread to complete.
            thread.Join();

            //immidiatly throws a ThreadAbortException which forces the thread to prematurely stop.
            thread.Abort();

            Console.ReadKey();
        }

        private void Operation()
        {
            Console.WriteLine("Hello from thread");
        }
    }
}
