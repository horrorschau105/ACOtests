using System.Collections.Generic;
using System;
using Combinatorics.Collections;
namespace main
{
    partial class Program
    {
        static int CalcShortPath(int from, int to)
        {
            int[] dist = new int[graph.Count];
            for(int i=0;i<dist.Length;++i) dist[i] = int.MaxValue;
            Queue<int> q = new Queue<int>();
            dist[from] = 0;
            q.Enqueue(from);
            while(q.Count > 0)
            {
                int top = q.Dequeue();
                foreach(Path p in graph[top])
                {
                    if(dist[p.to] > dist[p.from] + p.Length)
                    {
                        dist[p.to] = dist[p.from] + p.Length;
                        q.Enqueue(p.to);
                    }
                }
            }
            return dist[to];
        }
        static int ShortestCircuit()
        {
            int result = int.MaxValue;
            int curr;
            List<int> way;
            List<int> perm = new List<int>();
            for (int i = 1; i <= Verticles; ++i) perm.Add(i);
            var p = new Permutations<int>(perm);
            foreach(var v in p)
            {
                curr = 0;
                way = new List<int>() { 0 };
                way.AddRange(v);
                for (int i = 0; i <= Verticles; ++i) curr += graph[way[i]][way[(i + 1) % Verticles]].Length;
                result = Math.Min(result, curr);
            }
            return result;
        }
    }
}
