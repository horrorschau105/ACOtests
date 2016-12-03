using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    partial class Program
    {
        public const int N = 100000;// degree of Rudy's graph
        public const int VERTICLES = 8 * N + 5;
        public const int NEIGH = 2;// how many neighbours has each verticle
        public const int MAXLENGTH = 10;// max length of path
        static void Main(string[] args)
        {
            /* what to do
             * generate graph (at first directed, 5 paths from 1 verticle)
             * set begin and end
             * compute with dijskra best way
             * let ants go
             * wait for results
             * 
             */
            List<List<Path>> graph = GenerateGraph(N);
            foreach(List<Path> ver in graph)
            {
                foreach(Path p in ver)
                {
            //        Console.WriteLine("{0}\t{1}\t{2}", p.from, p.to, p.length);
                }
            }
            Console.WriteLine("Shortest Path: {0}", CalcShortPath(graph, 0, VERTICLES));

            Console.Read();
        }
    }
}
