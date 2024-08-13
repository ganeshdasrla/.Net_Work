using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ArthematicOperations
{
    public class Arthematic
    {
        private Arthematic @object;

        public Arthematic(Arthematic @object)
        {
            this.@object = @object;
        }

        public Arthematic() { }

        public int Sum(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
