using System;

namespace WCFClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference2.Service1Client svc = new ServiceReference2.Service1Client();
            svc.WaitForSomeTimeAsync(10000);
            Console.WriteLine("Client has executed");
        }
    }
}
