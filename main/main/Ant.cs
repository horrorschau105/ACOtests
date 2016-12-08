using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public class Ant
    {
        public int position { get; set; } // current verticle
        public int lengthOfWay;
        public List<Path> way; // list of visited verticles
        public bool searchingFood;
        Random r = new Random(1);
        public Ant(int pos=0)
        {
            position = pos;
            searchingFood = true;
            way = new List<Path>();
            lengthOfWay = 0;
        }
        public Path ChooseWay(List<Path> p)
        {
            double lower=0 ; // sum by all possible paths with pheromone 
            foreach(Path path in p)
            {
                lower += path.GetMultiplier();
            }
            double rand = r.NextDouble(); 
            foreach (Path path in p)
            {
                double probability = path.GetMultiplier() / lower;
                rand -= probability;
                if (rand < 0)
                {
                    this.way.Add(path);
                    return path;
                } 
            }
            throw new Exception("coś wysokie to pstwo");
           
         }
        public void Move(Path p)
        {
            this.position = p.to;
            this.lengthOfWay += p.Length;
            this.way.Add(p);
        }
        public void Clear()
        {
            position = 0;
            way = new List<Path>();
            lengthOfWay = 0;
        }
        
    }
}
