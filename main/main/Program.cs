﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    partial class Program
    {
        public const int Ants = 100; // count of ants;
        public const int Iterations = 100000;
        public const int Degree = 1000;// degree of Rudy's graph
        public const int Verticles = 8 * Degree + 5;
        public const int MaxLength = 50;// max length of path
        public const double Alpha = 0.5; // pheromone
        public const double Beta = 0.5; // length
        public const double Ro = 0.1; // evaporating
        public const double Q = 0.1; // adding pheromone
        public const double Bonus = 2; // prize for finding better way
        public static List<List<Path>> graph = GenerateGraph(Degree, Verticles);

        static void Main(string[] args)
        {
            int best = CalcShortPath(graph, 0, Verticles);
            List<Ant> ants = new List<Ant>();
            List<int> results = new List<int>() { MaxLength * Verticles};
            for (int j = 0; j < Ants; j++)  ants.Add(new Ant());
            double n = 0.0;
            Random r = new Random(105);
            for(int i=0;i<Iterations;++i)
            {
                foreach(var ant in ants)
                {
                    n = graph[ant.position].Sum(
                            (path => path.GetMultiplier())); // :)
                    foreach(var path in graph[ant.position])
                    {
                        if (r.NextDouble() > path.GetMultiplier() / n) continue;
                        ant.Move(path);
                        break;
                    }
                    if (ant.position == Verticles)  // in last verticle, move to start and update pheromones
                    {
                        var delta = Q / ant.lengthOfWay;
                        if (results.Min() > ant.lengthOfWay) ant.way.ForEach(path => path.pheromone += Bonus*delta);
                        else ant.way.ForEach(path => path.pheromone += delta);
                        results.Add(ant.lengthOfWay);
                        Console.WriteLine("{0}#: {1}", results.Count, ant.lengthOfWay);
                        ant.Clear();
                        graph.ForEach(list => list.ForEach(path => path.pheromone *= (1 - Ro)));
                    }
                }
            }
            Console.WriteLine($"Best found: {results.Min()}");
            Console.WriteLine($"Shortest Path: {best}");
            Console.WriteLine("fin");
            Console.Read();
        }
    }
}
