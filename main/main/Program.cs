using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    partial class Program
    {
        public const int N = 10;// degree of Rudy's graph
        public const int VERTICLES = 8 * N + 5;
        public const int MAXLENGTH = 200;// max length of path
        public const double PHERO_CONST = 0.1;
        public const double LENGTH_CONST = 0.1;
        public static List<List<Path>> graph = GenerateGraph(N);

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
           
            /*foreach(List<Path> ver in graph)
            {
                foreach(Path p in ver)
                {
                   Console.WriteLine("{0}\t{1}\t{2}", p.from, p.to, p.length);
                }
            }*/
            Console.WriteLine("Shortest Path: {0}", CalcShortPath(graph, 0, VERTICLES));
            Ant a;
            for(int i=0;i<100;++i)
            {
                a = new Ant(0.5);
                Console.WriteLine(a.Start());
            }
            /*while(a.position != VERTICLES)
            {
                Path next = a.ChooseWay(graph[a.position]);
                next.AddPheromone(a.pheromoneProduction);
                a.position = next.to;
                a.lengthOfWay += next.length;
                EvaporateAllPaths(graph, next.length / MAXLENGTH);

            }*/
            //Console.WriteLine(a.lengthOfWay);
            // ok, we have a graph
            /* now some ants
             * moving this way: repeat(move, evaporate)
             */
            Console.Read();
        }
    }
}
