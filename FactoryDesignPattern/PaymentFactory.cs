using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class PaymentFactory
    {
        public static IPayment Create(string payMethod)
        {
            switch (payMethod)
            {
                case "PhonePe":
                    return new PhonePe();

                case "GPay":
                    return new GPay();

                default:
                    throw new NotSupportedException($"{payMethod} is not supported");
            }
        }
    }
}
