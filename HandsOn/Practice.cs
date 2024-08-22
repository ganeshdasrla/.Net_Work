using System;
using System.Threading;

namespace ZHandsOn
{
    public static class Practice
    {
        private static int[] evenNumbers = { 2, 4, 6, 8, 10 };
        private static int[] oddNumbers = { 1, 3, 5, 7, 9, 11, 13, 15 };
        private static int evenIndex = 0;
        private static int oddIndex = 0;
        private static int totalNumbers = evenNumbers.Length + oddNumbers.Length;

        private static AutoResetEvent evenTurn = new AutoResetEvent(true);
        private static AutoResetEvent oddTurn = new AutoResetEvent(false);

        public static void Main()
        {
            Thread evenThread = new Thread(PrintEvenNumbers);
            Thread oddThread = new Thread(PrintOddNumbers);

            evenThread.Start();
            oddThread.Start();

            evenThread.Join();
            oddThread.Join();
        }

        private static void PrintEvenNumbers()
        {
            while (evenIndex + oddIndex < totalNumbers)
            {
                evenTurn.WaitOne(); // Wait for the turn to print even numbers

                if (evenIndex < evenNumbers.Length)
                {
                    Console.WriteLine(evenNumbers[evenIndex]);
                    evenIndex++;
                }

                oddTurn.Set(); // Signal that it's now odd numbers' turn
            }
        }

        private static void PrintOddNumbers()
        {
            while (evenIndex + oddIndex < totalNumbers)
            {
                oddTurn.WaitOne(); // Wait for the turn to print odd numbers

                if (oddIndex < oddNumbers.Length)
                {
                    Console.WriteLine(oddNumbers[oddIndex]);
                    oddIndex++;
                }

                evenTurn.Set(); // Signal that it's now even numbers' turn
            }
        }
    }
}
