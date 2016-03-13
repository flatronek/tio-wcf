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

    public class Starship
    {
        public string Name { get; set; }
        public Person Captain { get; set; }
        public List<Person> Crew { get; set; }

        public void TestMethod()
        {

        }

        public void PresentCrew()
        {
            Console.WriteLine("Ship: {0}", Name);
            Console.WriteLine("Captain: {0}, {1}", Captain.Name, Captain.Age);

            Crew.ForEach(p => Console.WriteLine("Crew member: {0}, {1}", p.Name, p.Age));
        }
    }
}
