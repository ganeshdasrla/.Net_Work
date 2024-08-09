using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class StatciSingletonLogger : SingletonBase
    {
        private StatciSingletonLogger() { }

        private static readonly StatciSingletonLogger Instance = new StatciSingletonLogger();
        public StatciSingletonLogger GetInstance()
        {
            return Instance;
        }
    }
}
