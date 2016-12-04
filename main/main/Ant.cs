using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public class Ant
    {
        public int position; // current verticle
        public int lengthOfWay;
        public List<int> way; // list of visited verticles
        public bool searchingFood;
        public double pheromoneProduction; // how much is it producting pheromon
        public Ant(double phP,int pos=0)
        {
            position = pos;
            searchingFood = true;
            pheromoneProduction = phP;
            way = new List<int>();
            lengthOfWay = 0;
        }
        public void LeavePheromone(Path path)
        {
            path.AddPheromone(pheromoneProduction);
        }
        public Path ChooseWay(List<Path> p)
        {
            // List<Path> possibly = new List<Path>();
            double lower; // sum by all possible paths with pheromone 
            lower = 0; // mianownik
            foreach(Path path in p)
            {
                    lower += Math.Pow(path.pheromone, Program.PHERO_CONST) * 
                             Math.Pow((1.0 / path.length), Program.LENGTH_CONST);
            }
            Random r = new Random();
            double rand = r.NextDouble();
            foreach(Path path in p)
            {
                rand -= (Math.Pow(path.pheromone, Program.PHERO_CONST) * 
                         Math.Pow((1.0 / path.length), Program.LENGTH_CONST)) / lower;
                if (rand < 0) return path;
            }
            return p.Last();
         }
        public int Start()
        {
            while (this.position != Program.VERTICLES)
            {
                Path next = this.ChooseWay(Program.graph[this.position]);
                next.AddPheromone(this.pheromoneProduction);
                this.position = next.to;
                this.lengthOfWay += next.length;
                Program.EvaporateAllPaths(Program.graph, next.length / Program.MAXLENGTH);

            }
            return this.lengthOfWay;
        }
    }
}
