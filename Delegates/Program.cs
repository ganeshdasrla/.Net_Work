using System;

namespace Delegates
{
    internal class Program
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }
        public static void LogOperation(int a, int b, string operation)
        {
            Console.WriteLine($"Performing {operation} on {a} and {b}");
        }

        public delegate int MathOperation(int a, int b);
        static void Main(string[] args)
        {
            MathOperation addOperation = Add;
            MathOperation multiplyOperation = Multiply;

            int result1 = addOperation(5, 3); // Returns 8
            Console.WriteLine(result1);

            int result2 = multiplyOperation(4, 2); // Returns 8
            Console.WriteLine(result2);


            MathOperation multicastDelegate = addOperation + multiplyOperation;
            multicastDelegate += (a, b) =>
            {
                LogOperation(a, b, "Addition and Multiplication");
                return 0;
            };


            Console.ReadLine();
        }
    }
}
