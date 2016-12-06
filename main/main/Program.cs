using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    partial class Program
    {
        public const int N = 20;// degree of Rudy's graph
        public const int VERTICLES = 8 * N + 5;
        public const int MAXLENGTH = 10;// max length of path
        public const double PHERO_CONST = 1.1;
        public const double LENGTH_CONST = 0.3;
        public const double PH_PROD = 0.3;
        public const double EVAPORATE_CONST = 0.5;
        public static List<List<Path>> graph = GenerateGraph(N);

        static void Main(string[] args)
        {
            int best = CalcShortPath(graph, 0, VERTICLES);
            Console.WriteLine("Shortest Path: {0}", best);
            Ant a;
            int result, oldres;
            result = 0;
            for(int i=0;i<100;++i)
            {
                a = new Ant(PH_PROD);
                oldres = result;
                result = a.Start();
                if (oldres != result) {
                    Console.WriteLine("Way: {1} / {0} \t Diff: {2}", result, i, diff(result, best));
             //       foreach (int v in a.way) Console.WriteLine(v);

                }
            }
            foreach(List <Path> list in graph)
            {
                foreach(Path p in list)
                {
             //       Console.WriteLine(p.pheromone);
                }
            }
            Console.WriteLine("fin");
            Console.Read();
        }
        static double diff(int best, int any)
        {
            return Math.Abs(best - any)*1.0 / best;
        }
    }
}
