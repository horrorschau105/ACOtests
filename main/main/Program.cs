﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    partial class Program
    {
        static public int Ants = 20; // count of ants;
        static public int Iterations = 1000;
        static public int Degree = 50;// degree of Rudy's graph
        static public int Verticles = 8 * Degree + 5;
        static public int MaxLength = 5;// max length of path
        static public double Alpha = 1; // pheromone
        static public double Beta = 1; // length
        static public double Ro = 0.3; // evaporating
        static public double Q = 2.14; // adding pheromone
        static public double Bonus = 7; // prize for finding better way
        static void Main()
        {
            double min = int.MaxValue;
            double curr;
            for (int i = 0; i < 1000; ++i)
            {
                Alpha += 0.01;
                for (int j = 0; j < 1000; ++j)
                {
                    Beta += 0.01;
                    curr = Testbild();
                    if (min > curr)
                    {
                        min = curr;
                        Console.WriteLine("{0}\t{1}\t{2}", Alpha, Beta, curr);
                    }
                }
                Beta -= 10;
            }
            Console.Write(min);
            Console.Read();
        }
        static double Testbild()
        {

            List<List<Path>> graph = GenerateGraph(Degree, Verticles);
            int best = CalcShortPath(graph, 0, Verticles);
            List<Ant> ants = new List<Ant>();
            List<int> results = new List<int>() { MaxLength * Verticles };
            for (int j = 0; j < Ants; j++) ants.Add(new Ant());
            double n = 0.0;
            Random r = new Random(105);
            for (int i = 0; i < Iterations; ++i)
            {
                foreach (var ant in ants)
                {
                    if (ant.position == Verticles)  // in last verticle, move to start and update pheromones
                    {
                        var delta = Q / ant.lengthOfWay;
                        if (results.Min() > ant.lengthOfWay) ant.way.ForEach(path => path.pheromone += Bonus * delta);
                        else ant.way.ForEach(path => path.pheromone += delta);
                        results.Add(ant.lengthOfWay);
                        //    Console.WriteLine("{0}#: {1}", results.Count, ant.lengthOfWay);
                        ant.Clear();
                        graph.ForEach(list => list.ForEach(path => path.pheromone *= (1 - Ro)));
                        graph.ForEach(list => list.ForEach(path => path.pheromone = (path.pheromone < 1.0 / Verticles ? 1.0 / Verticles : path.pheromone)));
                    }
                    n = graph[ant.position].Sum((path => path.GetMultiplier())); // :)
                    foreach (var path in graph[ant.position])
                    {
                        if (r.NextDouble() > path.GetMultiplier() / n) continue;
                        ant.Move(path);
                        break;
                    }
                }
            }
            return diff(results.Min(), best);
        }
        static double diff(int res, int best)
        {
            return Math.Abs(best - res) * 1.0 / res;
        }
    }
}