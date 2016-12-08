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
        public double pheromone { get; set; }
        public bool visited { get; set; }
        private int _length;
        public double InvertedLength { get; set; }
        public int Length
        {
            get { return _length; }
            set
            {
                _length = value;
                InvertedLength = 1.0 / value;
            }
        }

        public Path(int s, int e, int l,double ph=0)
        {
            from = s;
            to = e;
            pheromone = ph;
            visited = false;
            Length = l;
        }
        public void Update(double delta=0)
        {
            pheromone = (1-Program.Ro)*pheromone + delta;
        }
        public void Visit()
        {
            visited = true;
        }
        public double GetMultiplier()
        {
            return Math.Pow(this.pheromone, Program.Alpha) *
                   Math.Pow(InvertedLength, Program.Beta);
        }
    }
}
