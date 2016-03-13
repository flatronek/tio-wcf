using SpaceClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SpaceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BlackholeClient bc = new BlackholeClient();
                Console.WriteLine("Client created...");

                Starship ship = CreateStarship(35, 5);

                Console.WriteLine("Ultimae answer: {0} ", bc.UltimateAnswer());
                bc.PullStarship(ship);

                Console.ReadLine();
            }
            catch (CommunicationException e)
            {
                Console.WriteLine("Error occurred: " + e.Message);
            }
        }

        static Starship CreateStarship(int captainAge, int crewSize)
        {
            Person captain = new Person() { Name = "captain jack", Age = captainAge };

            List<Person> crew = new List<Person>();
            for (int i = 0; i < crewSize; i++)
            {
                crew.Add(new Person() { Name = "crewMember" + i, Age = captainAge - i });
            }

            return new Starship() { Name = "ship1", Captain = captain, Crew = crew.ToArray() };
        }
    }
}
