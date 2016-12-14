using System.Collections.Generic;
namespace main
{
    public class Ant
    {
        public int position { get; set; } // current verticle
        public int lengthOfWay;
        public List<Path> way; // list of visited verticles
        public Ant(int pos=0)
        {
            position = pos;
            way = new List<Path>();
            lengthOfWay = 0;
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
