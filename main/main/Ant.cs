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
        Random r = new Random(1);
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
            double lower=0 ; // sum by all possible paths with pheromone 
            foreach(Path path in p)
            {
                lower += path.GetMultiplier();
            }
            double rand = r.NextDouble(); 
            //Console.WriteLine(rand);
            foreach (Path path in p)
            {
                double probability = path.GetMultiplier() / lower;
                rand -= probability;
                if (rand < 0)
                {
                    this.way.Add(path.from);
                    return path;
                } 
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
                Program.EvaporateAllPaths(Program.graph, Program.EVAPORATE_CONST*next.length/Program.MAXLENGTH);

            }
            return this.lengthOfWay;
        }
    }
}
