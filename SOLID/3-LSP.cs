using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public interface IFruit {
        string GetColor();
    }

    public class Apple : IFruit
    {
        public string GetColor()
        {
            return "Red";
        }
    }

    public class Orange : IFruit
    {
        public string GetColor()
        {
            return "Orange";
        }
    }


    internal class LSP
    {
        static void Main(string[] args)
        {
            IFruit fruit = new Apple();
            Console.WriteLine(fruit.GetColor());
            fruit = new Orange();
            Console.WriteLine(fruit.GetColor());

            IFlyable fly = new Bird();
            fly.Fly();
            fly = new Penguin();
            fly.Fly();
        }

    }
    //LSP: Liskov Substitution Principle
    //LSP states that objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program

    //You should be able to use any subclass where you use its parent class.

    //You have remote control that works all types of TVs, regardless of the brand

    //Before LSP:
    public class Bird_Viloates_LSP
    {
        public virtual void Fly() { }
    }

    public class Penguin_LSP : Bird_Viloates_LSP
    {
        public override void Fly()
        {
            throw new NotImplementedException("Penguins can't fly!"); // This class violates the LSP throwing an exception for the fly method.
        }
    }

    //After applying LSP:
    public interface IFlyable
    {
        void Fly();
    }

    public class Bird : IFlyable
    {
        public void Fly()
        {
            //specific to bird 
        }
    }

    public class Penguin : IFlyable
    {
        public void Fly()
        {
            //implemtn specific to penguins
        }
    }
    //By adding IFlybale interface, both Bird and Penguin adhere to LSP

    //According to LSP, a dervied class shoul not break the base class's type defination and behaviour, which means objects of a base class shall be replaceable with the objects of its dervide classes without breaking application.


}






    
