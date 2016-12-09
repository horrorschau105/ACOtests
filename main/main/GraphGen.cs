﻿using System;
using System.Collections.Generic;
namespace main
{
    partial class Program
    {
        static public List<List<Path>> GenerateGraph(int degree, int verticles)
        {
            Random r = new Random();
            List<List<Path>> res = new List<List<Path>>();
            List<Path> verticle = new List<Path>();
            for(int i=1;i<=4;++i)      verticle.Add(new Path(0, i, r.Next(1, MaxLength), 1.0/verticles));
            res.Add(verticle);                                                              
            for (int i=0;i<degree;++i)                                                      
            {                                                                               
                for (int j = 0; j < 8; j++) res.Add(new List<Path>());                      
                res[8 * i + 2].Add(new Path(8 * i + 2, 8 * i + 1 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 3].Add(new Path(8 * i + 3, 8 * i + 2 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 4].Add(new Path(8 * i + 4, 8 * i + 3 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 5].Add(new Path(8 * i + 5, 8 * i + 6 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 6].Add(new Path(8 * i + 6, 8 * i + 7 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 7].Add(new Path(8 * i + 7, 8 * i + 8 , r.Next(1, MaxLength), 1.0/verticles));// pion
                res[8 * i + 5].Add(new Path(8 * i + 5, 8 * i + 9 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 6].Add(new Path(8 * i + 6, 8 * i + 10, r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 7].Add(new Path(8 * i + 7, 8 * i + 11, r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 8].Add(new Path(8 * i + 8, 8 * i + 12, r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 1].Add(new Path(8 * i + 1, 8 * i + 5 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 2].Add(new Path(8 * i + 2, 8 * i + 6 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 3].Add(new Path(8 * i + 3, 8 * i + 7 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 4].Add(new Path(8 * i + 4, 8 * i + 8 , r.Next(1, MaxLength), 1.0/verticles)); // poziom
                res[8 * i + 2].Add(new Path(8 * i + 2, 8 * i + 5 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 3].Add(new Path(8 * i + 3, 8 * i + 6 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 4].Add(new Path(8 * i + 4, 8 * i + 7 , r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 5].Add(new Path(8 * i + 5, 8 * i + 10, r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 6].Add(new Path(8 * i + 6, 8 * i + 11, r.Next(1, MaxLength), 1.0/verticles));
                res[8 * i + 7].Add(new Path(8 * i + 7, 8 * i + 12, r.Next(1, MaxLength), 1.0/verticles));   
            }                                                                              
            for (int i = 1; i <= 4; ++i) res.Add(new List<Path>() {                   
                          new Path(8 * degree + i, 8 * degree + 5, r.Next(1, MaxLength), 1.0/verticles) });
            res.Add(new List<Path>()); // empty list for last verticle
            return res;
        }
    }
}
