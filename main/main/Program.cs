using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    partial class Program
    {
        public const int Ants = 1000; // count of ants;
        public const int Iterations = 1000;
        public const int Degree = 100;// degree of Rudy's graph
        public const int Verticles = 8 * Degree + 5;
        public const int MaxLength = 50;// max length of path
        public const double Alpha = 1; // wykladnik
        public const double Beta = 0.5; // wykladnik
        public const double Ro = 0.1; // p in (1-p)*pheromone
        public const double Q = 1; /// adding pheromone
        public static List<List<Path>> graph = GenerateGraph(Degree, Verticles);

        static void Main(string[] args)
        {
            
            int best = CalcShortPath(graph, 0, Verticles);
            List<Ant> ants = new List<Ant>();
            List<int> results = new List<int>();
            for (int j = 0; j < Ants; j++)  ants.Add(new Ant());
            //int result, oldres;
            //result = 0;
            double n=0.0;
            Random r = new Random(105);
            for(int i=0;i<Iterations;++i)
            {
                foreach(var ant in ants)
                {
                    n = graph[ant.position].Sum(
                            (path => path.GetMultiplier())); // :)
                    foreach(var path in graph[ant.position])
                    {
                        if (r.NextDouble() > path.GetMultiplier() / n) continue; // why does it work?
                        ant.Move(path);
                        break;
                    }
                    if (ant.position == Verticles)  // in last verticle, move to start and update pheromones
                    {
                        var delta = Q / ant.lengthOfWay;
                        ant.way.ForEach(path => path.pheromone += delta);
                        results.Add(ant.lengthOfWay);
                        ant.Clear();
                    }
                }
            }
            foreach (var res in results) Console.WriteLine(res);
            Console.WriteLine($"Best found: {results.Min()}");
            Console.WriteLine($"Shortest Path: {best}");

            /* for (int i = 0; i < ANTS; ++i)
             {
                 a = new Ant();
                 oldres = result;
                 result = a.Start();
                 if (oldres != result)
                 {
                     Console.WriteLine("Way: {1} / {0} \t Diff: {2}", result, i, diff(result, best));
          //          foreach (List<Path> list in graph) { foreach (Path p in list) { Console.WriteLine(p.pheromone); } }
                     //       foreach (int v in a.way) Console.WriteLine(v);

                 }
             }*/
            //   foreach (List<Path> list in graph) { foreach (Path p in list) { Console.WriteLine(p.pheromone); } }

            Console.WriteLine("fin");
            Console.Read();
        }
        static double diff(int best, int any)
        {
            return Math.Abs(best - any)*1.0 / best;
        }
    }
}
