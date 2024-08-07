using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    internal class _5_DIP
    {
    }
    //DIP: Dependency Inversion Principle
    //DIP suugest that high level modules should not depend on low-level modules, but both should depend on abstractions.
    //Additionally, abstraction should not depend on details, details should depend on abstractions

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
