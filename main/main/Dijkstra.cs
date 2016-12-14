using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    partial class Program
    {
        static int CalcShortPath(List<List<Path>> graph, int from, int to)
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
    }
}
