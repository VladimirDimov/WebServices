using StringCounter.Service;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace IISClient
{
    class Program
    {
        static void Main()
        {
            var serviceAddress = new Uri("http://localhost:56599/StringCounterService.svc");
            ServiceHost selfHost = new ServiceHost(
                typeof(StringCounterService), serviceAddress);

            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            selfHost.Open();
            Console.WriteLine("Running at " + serviceAddress);

            StringCounterServiceClient client = new StringCounterServiceClient();

            using (client)
            {
                var text = "asd asd asd qeqwrqwr asdasd";
                var requestedString = "asd";
                var result = client.Count(text, requestedString);
                Console.WriteLine("Text: {0}; Requested string: {1}; Result: {2}", text, requestedString, result);
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
