using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    partial class Program
    {
        static public List<List<Path>> GenerateGraph(int n, int neigh)
        {
            Random r = new Random();
            List<List<Path>> res = new List<List<Path>>();
            int iterator = 0;
            int created = 1;
            for(;iterator<n;++iterator)
            {
                List<Path> subtree = new List<Path>();
                for(int j=0;j<neigh;++j)
                {
                    subtree.Add(new Path(iterator, Math.Min(created,n), r.Next(1, 6), r.NextDouble()));
                    if (created > n) break;
                    created++;
                }
                res.Add(subtree);
            }
            return res;
        }
    }
}
