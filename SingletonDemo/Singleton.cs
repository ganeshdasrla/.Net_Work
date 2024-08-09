using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    //Sealed restrics the inheritance
    public sealed class Singleton
    {
        private static int counter = 0;
        private static readonly object obj = new object();

        //------------------ USING LOC, handle multi threading concepts------------------
        //private static Singleton instance = null;
        //public property used to return only one instance of the class leveraging on the private property
        //public static Singleton GetInstance
        //{
        //    get
        //    {
        //        if (instance == null) //DOUBLE CHECK LOCKING
        //        {
        //            //lock ensures that only one thread enters at a time in this critical section of code
        //            lock (obj) //This is expensive program, to avoid loc cheking unnecessarily, add extra conditon before this like above
        //            {
        //                if (instance == null)
        //                    instance = new Singleton();
        //            }
        //        }
        //        return instance;
        //    }
        //}

        //--- EAGER LOADING
        //private static readonly Singleton instance = new Singleton(); //CLR takes care of thread safety in paralell programing
        //public static Singleton GetInstance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}


        //---AS LOC expensive, USE LAZY LOADING -- in .Net 4.0
        //This take care intializing in lazy loading, Lazy is thread safe
        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());
        public static Singleton GetInstance
        {
            get
            {
                return instance.Value;
            }
        }


        //Private constructor ensures that object is not instantiated other that with in the class
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value: " + counter);
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
