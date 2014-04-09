using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using ConsoleApplication1;

namespace Coursework
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost serviceHost = new ServiceHost(typeof(Service));
            

            serviceHost.Open();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The service is ready.");
            Console.ResetColor();
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.ReadLine();

            serviceHost.Close();


        }
    }
}

