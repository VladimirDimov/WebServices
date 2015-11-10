using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MmessageService;
using System.ServiceModel.Description;

namespace MessageServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:1234";
            ServiceHost host = new ServiceHost(typeof(MessageService), new Uri(url));

            // Setting behavior
            var behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;

            // adding the behavior
            host.Description.Behaviors.Add(behavior);

            host.Open();
            Console.WriteLine("Serverlistening on {0}", url);
            Console.ReadLine();
            host.Close();
        }
    }
}
