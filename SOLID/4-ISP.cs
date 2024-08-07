using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    internal class ISP
    {
    }

    //ISP: Interface Segregation Principle
    //ISP states that a class should not be forced to implement interfaces it doesn't use.
    //ISP encourages creation of small and clint specific interfaces

    //A class should n't be forced to implement interfaces it doesn't use

    //You sign up for a music streaming service and only choose the genres you like, not all available genres

    //Before ISP:
    public interface IWorker
    {
        void Work();
        void Eat();
    }

    public class Manager : IWorker
    {
        public void Eat()
        {
            //Implemetation
        }

        public void Work()
        {
            //Implementation
        }
    }

    public class Robot : IWorker
    {
        public void Eat()
        {
            throw new NotImplementedException(); //Violation of ISP, This class is forced to implement Eat method.
        }

        public void Work()
        {
            throw new NotImplementedException();
        }
    }

    //After applying ISP:
    public interface IWorkable
    {
        void work();
    }
    public interface IEatble
    {
        void Eat();
    }
    //BY splitting the IWorker interface into small interfaces, IWorkable, IEatble
    //so then classes can implement what they need

    //Accoring to LSP, any class should not forced to use an interface that is irrelevant to it.
    //Client should not be forced to depend on methods that they don't use
}
