using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCFServices;

namespace WCFConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost studentServiceHost = null;

            try
            {
                //Base Address for StudentService
                Uri httpBaseAddress = new Uri("http://localhost:4321/StudentService");

                //Instantiate ServiceHost
                studentServiceHost = new ServiceHost(typeof(Service1),
                    httpBaseAddress);

                //Add Endpoint to Host
                studentServiceHost.AddServiceEndpoint(typeof(Service1),
                                                        new WSHttpBinding(), "");

                //Metadata Exchange
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                studentServiceHost.Description.Behaviors.Add(serviceBehavior);

                //Open
                studentServiceHost.Open();
                Console.WriteLine("Service is live now at: { 0} ", httpBaseAddress);
            }
            catch (Exception ex)
            {
                studentServiceHost = null;
                Console.WriteLine("There is an issue with StudentService" + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
