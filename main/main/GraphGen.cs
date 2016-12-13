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
            for (int i = 0; i <= Verticles; ++i)
            {
                res.Add(new List<Path>());
                for (int j = 0; j <= Verticles; ++j) 
                {
                    res[i].Add(new Path(-1, -1, -1));
                }
            }
            for (int i = 0; i <= Verticles; ++i)
            {
                for (int j = i; j <= Verticles; ++j)
                {
                    res[i][j] = new Path(i, j, r.Next(1, MaxLength), 1.0 / Verticles);
                }
            }
            for (int i = 0; i <= Verticles; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    res[i][j] = new Path(i, j, res[j][i].Length, res[j][i].pheromone);
                }
            }
            //res.ForEach(list => { list.ForEach(path => Console.Write(path.Length)); Console.WriteLine(); });
            return res;

        }
    }
}
