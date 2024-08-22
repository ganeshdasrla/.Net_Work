using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    internal class DIP
    {
    }
    //DIP: Dependency Inversion Principle
    //DIP suugest that high level modules should not depend on low-level modules, but both should depend on abstractions.
    //Additionally, abstraction should not depend on details, details should depend on abstractions

    //Entities/Classes should depend on abstraction and not on concrete classes.

    //High-level modules should not depend on low-level modules, both should depend on abstractions.

    //Building a LEGO tower, the bricks(high and low-level modules) connect through smallar bricks(abstractions)

    public class LightBulb_Voilates_DIP
    {
        public bool IsOn { get; internal set; }

        public void TurnOn() { 
        //imple
        }
        public void TurnOff() { }
    }

    public class Switch_Voilates_DIP //Directly depending on LightBulb class
    {
        private LightBulb_Voilates_DIP bulb;

        public Switch_Voilates_DIP(LightBulb_Voilates_DIP bulb)
        {
            this.bulb = bulb;
        }

        public void Toggle()
        {
            if (bulb.IsOn)
            {
                bulb.TurnOff();
            }
            else
            {
                bulb.TurnOn();
            }
        }
    }
    //The Switch class directly dependent on conecrete LightBulb class

    //After applying in DIP
    public interface ISwitchable
    {
        bool IsOn { get; }

        void TurnOff();
        void TurnOn();
    }

    public class LightBulb : ISwitchable
    {
        public bool IsOn => throw new NotImplementedException();

        public void TurnOff()
        {
            //implementation
        }

        public void TurnOn()
        {
            //implementation
        }
    }

    public class Switch
    {
        private ISwitchable device;

        public Switch(ISwitchable device)
        {
            this.device = device;
        }

        public void Toggle()
        {
            if (device.IsOn)
            {
                device.TurnOff();
            }
            else
            {
                device.TurnOn();
            }
        }
    }
    //By introducing an interface ISwitchable, the Switch class depends on abstraction

    //According to DIP, do not write any tightly coupled code because that is nightmare to maintain when the application is growing bigger and bigger.
    //If a class depends on another class, then we need to change one class if something changes in that dependent class, we should always try to write loosely coupled classes.
}


// Low-level module
public class PaymentServicee
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C}");
    }
}

// High-level module
public class OrderProcessore
{
    private PaymentServicee _paymentService;

    public OrderProcessore()
    {
        _paymentService = new PaymentServicee();
    }

    public void ProcessOrder(decimal amount)
    {
        // Process order and payment
        Console.WriteLine("Processing order...");
        _paymentService.ProcessPayment(amount);
    }
}
//Issues with this Design
//Tight Coupling: OrderProcessor is tightly coupled to PaymentService. If you need to change PaymentService or use a different payment method, you have to modify OrderProcessor.
//Hard to Test: It's difficult to test OrderProcessor in isolation because it directly depends on a concrete implementation of PaymentService.


//Define an interface IPaymentService that abstracts the payment processing functionality.
public interface IPaymentService
{
    void ProcessPayment(decimal amount);
}

//Implement the IPaymentService interface in the PaymentService class.

// Low-level module
public class PaymentService : IPaymentService
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C}");
    }
}

// High-level module
public class OrderProcessor
{
    private readonly IPaymentService _paymentService;

    public OrderProcessor(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public void ProcessOrder(decimal amount)
    {
        // Process order and payment
        Console.WriteLine("Processing order...");
        _paymentService.ProcessPayment(amount);
    }
}

public class Program
{
    public static void Main()
    {
        IPaymentService paymentService = new PaymentService();
        OrderProcessor orderProcessor = new OrderProcessor(paymentService);

        orderProcessor.ProcessOrder(100);
    }
}

//Benefits of the Refactored Design
//Looser Coupling: OrderProcessor no longer depends on a concrete implementation of PaymentService.
//It depends on the abstraction IPaymentService, which can be easily swapped out for another implementation if needed.
//Easier Testing: You can easily mock or stub IPaymentService in unit tests for OrderProcessor.
//Flexible and Maintainable: Adding new payment services or modifying existing ones does not require changes to OrderProcessor.