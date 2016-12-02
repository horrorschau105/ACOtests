using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public class Path
    {
        public int from;
        public int to;
        public double pheromone;
        public bool visited;

        public Path(int s, int e, double ph=0)
        {
            from = s;
            to = e;
            pheromone = ph;
            visited = false;
        }
        public void AddPheromone(double add)
        {
            pheromone += add;
        }
        public void Visit()
        {
            visited = true;
        }
        public void WindOut(double prc) // after period of time the smell of pheromone have to be weaker
        {
            pheromone *= prc;
        }
    }
}
