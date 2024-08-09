using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class ClassicSingletonLogger : SingletonBase
    {
        private static ClassicSingletonLogger instance;

        private ClassicSingletonLogger() { }

        public static ClassicSingletonLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new ClassicSingletonLogger();
            }
            return instance;
        }
    }
}
