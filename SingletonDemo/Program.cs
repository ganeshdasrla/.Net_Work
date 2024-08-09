using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingletonBase s1 = ClassicSingletonLogger.GetInstance();
            SingletonBase s2 = ClassicSingletonLogger.GetInstance();
            if (s1 == s2)
            {
                Console.WriteLine("Same instance");
            }


            Parallel.Invoke(
                () => FirstObject(),
                () => SecondObject()
            );

            Console.ReadLine();
        }

        private static void FirstObject()
        {
            Singleton ob1 = Singleton.GetInstance;
            ob1.PrintDetails("This from first object");
        }

        private static void SecondObject()
        {
            Singleton ob2 = Singleton.GetInstance;
            ob2.PrintDetails("This from second object");
        }
    }
}
