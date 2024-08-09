using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public interface ICar
    {
        void Start();
    }

    public class SixSeater : ICar
    {
        public void Start() { }
    }

    public class FourSeater : ICar
    {
        public void Start() { }
    }


    //This factory, hides the logic of instantiaion
    //Reduce the duplicity of code
    //One place changes will change everywhere
    public class CarFactory { 
        
        public ICar GetCar(string carType)
        {
            switch (carType)
            {
                case "SixSeater":
                        return new SixSeater();
                case "FourSeater":
                    return new FourSeater();

            }
            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IPayment obj = PaymentFactory.Create("PhonePe");
            obj.Pay(1000);

            IPayment obj1 = PaymentFactory.Create("GPay");
            obj1.Pay(1000);

            Console.ReadLine();

            CarFactory factory = new CarFactory();


            ICar sixCar = factory.GetCar("SixSeater");
            ICar fourCar = factory.GetCar("FourSeater");
        }
    }
}
