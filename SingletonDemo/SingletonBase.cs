using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public abstract class SingletonBase
    {
        public void Log(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
