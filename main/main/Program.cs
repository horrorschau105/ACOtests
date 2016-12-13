using System;
using System.Collections.Generic;
using System.Linq;
namespace main
{
    partial class Program
    {
        public const int Ants = 1; // count of ants;
        public const int Iterations = 100000;
        public const int Verticles = 9;
        public const int MaxLength = 10;// max length of path
        public const double Alpha = 1; // wykladnik
        public const double Beta = 1; // wykladnik
        public const double Ro = 0.01; // p in (1-p)*pheromone
        public const double Q = 2; // adding pheromone
        public const double Bonus = 1; // prize for finding better way
        public static List<List<Path>> graph = GenerateGraph();

        static void Main(string[] args)
        {
            int best = ShortestCircuit();
            List<Ant> ants = new List<Ant>();
            List<int> results = new List<int>() { MaxLength * Verticles};
            List<Ant> finished = new List<Ant>();
            Random r = new Random(105);
            for (int j = 0; j < Ants; j++) ants.Add(new Ant(r.Next(0, Verticles+1)));
            double n = 0.0;
            for(int i=0;i<Iterations;++i)
            {
                // pusc mrowki
                // wez wynik
                foreach(var ant in ants)
                {
                    if (ant.visits == Verticles-1)
                    {
                        ant.visits++;
                        ant.lengthOfWay += graph[ant.start_city][ant.way.Last().to].Length;
                        ant.way.Add(graph[ant.start_city][ant.way.Last().to]);
                        results.Add(ant.lengthOfWay);
                        var delta = Q / ant.lengthOfWay;
                        ant.way.ForEach(path => path.pheromone += Bonus * delta);
                        graph.ForEach(l => l.ForEach(path => path.pheromone *= (1 - Ro)));
                        ant.Clear();
                    }
                    var possible = graph[ant.position].Where(path => !ant.cities[path.to]);
                    if (possible.Count() == 0) ant.Clear();
                    n = possible.Sum((path => path.GetMultiplier())); // :)
                    foreach(var path in possible)
                    {
                        if (r.NextDouble() < path.GetMultiplier() / n) continue;
                        ant.Move(path);
                        ant.cities[path.to] = true;
                        ant.visits++;
                        break;
                    }
                }
            }
            Console.WriteLine($"Best global: {best}");
            Console.WriteLine($"Best found: {results.Min()}");
            Console.WriteLine("fin");
            Console.Read();
        }
    }
}
