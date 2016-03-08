using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    public class Blackhole : IBlackhole
    {
        public Starship PullStarship(Starship ship)
        {
            if (ship.Captain.Age <= 40)
            {
                ship.Captain.Age += 20;
                ship.Crew.ForEach(c => c.Age += 20);
            }

            return ship;
        }

        public string UltimateAnswer()
        {
            return 42.ToString();
        }
    }
}
