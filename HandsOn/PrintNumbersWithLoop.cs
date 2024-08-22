using System;

public class PrintNumbersWithLoop
{
    public static void Main()
    {
        int[] evenNumbers = { 2, 4, 6, 8 };
        int[] oddNumbers = { 1, 3, 5, 7 };

        int length = Math.Min(evenNumbers.Length, oddNumbers.Length);

        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(oddNumbers[i]);
            Console.WriteLine(evenNumbers[i]);
        }

        if (evenNumbers.Length > length)
        {
            for (int i = length; i < evenNumbers.Length; i++)
            {
                Console.WriteLine(evenNumbers[i]);
            }
        }

        if (oddNumbers.Length > length)
        {
            for (int i = length; i < oddNumbers.Length; i++)
            {
                Console.WriteLine(oddNumbers[i]);
            }
        }
    }
}