using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:9000/space");
            ServiceHost sh = new ServiceHost(typeof(Blackhole), address);

            try
            {
                sh.AddServiceEndpoint(typeof(IBlackhole), new WSHttpBinding(), "test");

                ServiceMetadataBehavior smd = new ServiceMetadataBehavior();
                smd.HttpGetEnabled = true;

                sh.Description.Behaviors.Add(smd);
                sh.Open();

                Console.WriteLine("Service running...");
                Console.ReadLine();

                sh.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("Exception occured: {0}", ex.Message);

                sh.Abort();
            }
        }
    }
}
