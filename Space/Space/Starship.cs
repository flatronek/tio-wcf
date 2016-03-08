using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    public class Starship
    {
        public string Name { get; set; }
        public Person Captain { get; set; }
        public List<Person> Crew { get; set; }
        
        public void PresentCrew()
        {
            Console.WriteLine("Ship: {0}", Name);
            Console.WriteLine("Captain: {0}, {1}", Captain.Name, Captain.Age);

            Crew.ForEach(p => Console.WriteLine("Crew member: {0}, {1}", p.Name, p.Age));
        }
    }
}
