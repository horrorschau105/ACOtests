using System.Collections.Generic;


namespace main
{
    public class Ant
    {
        public int position { get; set; } // current verticle
        public int lengthOfWay;
        public List<Path> way; // list of visited verticles
        public List<bool> cities;
        public int visits;
        public int start_city;
        public Ant(int pos=0)
        {
            position = pos;
            start_city = pos;
            way = new List<Path>();
            visits = 0;
            lengthOfWay = 0;
            cities = new List<bool>();
            for (int i = 0; i <= Program.Verticles; ++i) cities.Add(false);
            cities[position] = true;
        }
        public void Move(Path p)
        {
            this.position = p.to;
            this.lengthOfWay += p.Length;
            this.way.Add(p);
        }
        public void Clear()
        {
            position = start_city;
            visits = 0;
            way = new List<Path>();
            lengthOfWay = 0;
            for (int i = 0; i <= Program.Verticles; ++i) cities[i] = false;
            cities[position] = true;
        }
    }
}
