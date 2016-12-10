using System;
using System.Collections.Generic;
namespace main
{
    partial class Program
    {
        static public List<List<Path>> GenerateGraph()
        {
            Random r = new Random();
            List<List<Path>> res = new List<List<Path>>();
            for (int i = 0; i <= Verticles; ++i) res.Add(new List<Path>());
                for (int i = 0; i <= Verticles; ++i)
                {
                    for (int j = i + 1; j <= Verticles; ++j)
                    {
                        Path p = new Path(i, j, r.Next(1, MaxLength), 1.0 / Verticles);
                        res[i].Add(p);
                        p.from = j; p.to = i;
                        res[j].Add(p);
                    }
                }
            
            return res;
        }
    }
}
