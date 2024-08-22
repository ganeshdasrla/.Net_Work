using System;
using System.Threading;

public class Program
{
    private static int[] evenNumbers = { 2, 4, 6, 8 };
    private static int[] oddNumbers = { 1, 3, 5, 7 };
    private static int index = 0;

    private static AutoResetEvent evenTurn = new AutoResetEvent(false); // Even thread starts first
    private static AutoResetEvent oddTurn = new AutoResetEvent(true); // Odd thread waits initially

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
        while (index < evenNumbers.Length + oddNumbers.Length)
        {
            evenTurn.WaitOne(); // Wait until it's the even thread's turn

            if (index / 2 < evenNumbers.Length)
            {
                Console.WriteLine(evenNumbers[index / 2]);
                index++;
            }

            oddTurn.Set(); // Signal the odd thread to continue
        }
    }

    private static void PrintOddNumbers()
    {
        while (index < evenNumbers.Length + oddNumbers.Length)
        {
            oddTurn.WaitOne(); // Wait until it's the odd thread's turn

            if (index / 2 < oddNumbers.Length)
            {
                Console.WriteLine(oddNumbers[index / 2]);
                index++;
            }

            evenTurn.Set(); // Signal the even thread to continue
        }
    }
}
