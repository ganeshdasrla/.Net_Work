using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class ThreadSafeSingletonLogger : SingletonBase
    {
        private static readonly object threadLock = new object();

        private static ThreadSafeSingletonLogger instance;

        private ThreadSafeSingletonLogger() { }
        public static ThreadSafeSingletonLogger GetInstance()
        {
            if (instance == null)
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeSingletonLogger();
                    }
                }
            }
            return instance;
        }
    }
}
