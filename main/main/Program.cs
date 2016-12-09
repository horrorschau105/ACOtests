using System;
using System.Collections.Generic;
using System.Linq;
namespace main
{
    partial class Program
    {
        public const int Ants = 100; // count of ants;
        public const int Iterations = 1000;
        public const int Degree = 100;// degree of Rudy's graph
        public const int Verticles = 8 * Degree + 5;
        public const int MaxLength = 5;// max length of path
        public const double Alpha = 0.5; // wykladnik
        public const double Beta = 3.5; // wykladnik
        public const double Ro = 0.24; // p in (1-p)*pheromone
        public const double Q = 0.14; // adding pheromone
        public const double Bonus = 5; // prize for finding better way
        public static List<List<Path>> graph = GenerateGraph(Degree, Verticles);

        static void Main(string[] args)
        {
            int best = CalcShortPath(graph, 0, Verticles);
            List<Ant> ants = new List<Ant>();
            List<int> results = new List<int>() { MaxLength * Verticles};
            List<Ant> finished = new List<Ant>();
            for (int j = 0; j < Ants; j++)  ants.Add(new Ant());
            double n = 0.0;
            Random r = new Random(105);
            for(int i=0;i<Iterations;++i)
            {
                foreach(var ant in ants)
                {
                    if (ant.position == Verticles)  finished.Add(ant);
                    if (finished.Count == Ants)
                    {
                        ASrank(finished, results);
                        finished = new List<Ant>();
                    }
                    n = graph[ant.position].Sum(
                            (path => path.GetMultiplier())); // :)
                    foreach(var path in graph[ant.position])
                    {
                        if (r.NextDouble() > path.GetMultiplier() / n) continue;
                        ant.Move(path);
                        break;
                    }
                }
            }
            Console.WriteLine($"Best found: {results.Min()}");
            Console.WriteLine($"Shortest Path: {best}");
            Console.WriteLine("fin");
            Console.Read();
        }
        static void ASrank(List<Ant> list, List<int> results)
        {
            results.AddRange(list.Select(ant => ant.lengthOfWay));
            var sorted = list.OrderBy(ant => ant.lengthOfWay).ToList(); // ascending
            int count = list.Count;
            int index = 0;
            foreach (var ant in sorted)
            {
                double delta = Q*1.0 / ant.lengthOfWay;
                ant.way.ForEach(path => path.pheromone += Bonus * (2.0 - index / count) * delta);
                index++;
            }
            list.ForEach(ant => ant.Clear());
            graph.ForEach(l => l.ForEach(path => path.pheromone *= (1 - Ro)));
        }
    }
}
