using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class LazySingletonLogger : SingletonBase
    {
        private LazySingletonLogger() { }

        private static readonly Lazy<LazySingletonLogger> instance
            = new Lazy<LazySingletonLogger>(() => new LazySingletonLogger());
        public LazySingletonLogger GetInstance()
        {
            return instance.Value;
        }
    }
}
