using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    partial class Program
    {
        static void Main(string[] args)
        {
            /* what to do
             * generate graph (at first directed, 5 paths from 1 verticle)
             * set begin and end
             * compute with dijskra best way
             * let ants go
             * wait for results
             * 
             */
            List<List<Path>> graph = GenerateGraph(10, 2);
            foreach(List<Path> ver in graph)
            {
                foreach(Path p in ver)
                {
                    Console.WriteLine("{0}\t{1}", p.from, p.to);
                }
            }

            Console.Read();
        }
    }
}
