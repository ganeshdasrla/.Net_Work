using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{

    public class GPay : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Successfully paid {amount} to marchant using GPay");
        }
    }
}
