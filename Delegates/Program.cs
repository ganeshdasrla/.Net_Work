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

        //Generic Delegate
        //:::A generic delegate allows you to create a delegate that can work with any type specified when the delegate is used. 
        //The MyGenericDelegate<T> delegate is defined to take a parameter of type T and return a value of type T. This makes the delegate flexible enough to work with any data type.
        public delegate T MyGenericDelegate<T>(T item);

        public static int DoubleInt(int number)
        {
            return number * 2;
        }

        public static string RepeatString(string str) {
            return str + str;
        }

        static void Main(string[] args)
        {
            MyGenericDelegate<int> intDel = new MyGenericDelegate<int>(DoubleInt);
            int resg = intDel(5);
            Console.WriteLine(resg);

            MyGenericDelegate<string> strinDel = new MyGenericDelegate<string>(RepeatString);
            string resgs = strinDel("Hello");
            Console.WriteLine(resgs);


            MathOperation del = new MathOperation(Add);

            Console.WriteLine(del.Invoke(10, 6));

            var res = del(10, 5);
            Console.WriteLine(res);

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

            MathOperation del1 = new MathOperation(Add);
            MathOperation del2 = new MathOperation(Multiply);
            MathOperation del3 = del1 + del2;

            foreach(MathOperation dell in del3.GetInvocationList())
            {
                var result = dell(10, 5);
                Console.WriteLine(result);
            }


            Console.ReadLine();
        }
    }
}
