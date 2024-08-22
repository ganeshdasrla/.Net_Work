using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    public class EvenOddPrinter
    {
        private int maxNumber;
        private int currentNumber = 1;

        private AutoResetEvent oddEvent = new AutoResetEvent(true);
        private AutoResetEvent evenEvent = new AutoResetEvent(false);

        public EvenOddPrinter(int maxNumber)
        {
            this.maxNumber = maxNumber;
        }

        public void PrintOddNumbers()
        {
            while (currentNumber <= maxNumber)
            {
                oddEvent.WaitOne(); // Wait for the oddEvent signal
                if (currentNumber <= maxNumber && currentNumber % 2 != 0)
                {
                    Console.WriteLine(currentNumber);
                    currentNumber++;
                }
                evenEvent.Set(); // Signal the evenEvent
            }
        }

        public void PrintEvenNumbers()
        {
            while (currentNumber <= maxNumber)
            {
                evenEvent.WaitOne(); // Wait for the evenEvent signal
                if (currentNumber <= maxNumber && currentNumber % 2 == 0)
                {
                    Console.WriteLine(currentNumber);
                    currentNumber++;
                }
                oddEvent.Set(); // Signal the oddEvent
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = 7;
            EvenOddPrinter printer = new EvenOddPrinter(maxNumber);

            Thread oddThread = new Thread(printer.PrintOddNumbers);
            Thread evenThread = new Thread(printer.PrintEvenNumbers);

            oddThread.Start();
            evenThread.Start();

            oddThread.Join();
            evenThread.Join();


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

        private static void Operation()
        {
            Console.WriteLine("Hello from thread");
        }
    }
}
