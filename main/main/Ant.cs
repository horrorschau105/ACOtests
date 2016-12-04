using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    class Ant
    {
        public int position; // current verticle
        public List<int> way; // list of visited verticles
        public bool searchingFood;
        public double pheromoneProduction; // how much is it producting pheromon
        public Ant(double phP,int pos=0)
        {
            position = pos;
            searchingFood = true;
            pheromoneProduction = phP;
            way = new List<int>();
        }
        public void LeavePheromone(Path path)
        {
            path.AddPheromone(pheromoneProduction);
        }
        public void ChooseWay(List<Path> p)
        {
            /* take all posible paths
             * sum up all pheremone 
             */
        
        }
    }
}
