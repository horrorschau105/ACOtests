using System;
namespace main
{
    public class Path
    {
        public int from;
        public int to;
        public double pheromone { get; set; }
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
            Length = l;
        }
        public double GetMultiplier()
        {
            return Math.Pow(this.pheromone, Program.Alpha) *
                   Math.Pow(InvertedLength, Program.Beta);
        }
    }
}
