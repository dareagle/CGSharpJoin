using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace SharpJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            string output;
            List<string[]> fileZ = Directory.GetFiles(".").Where(n => n.LastIndexOf(".cs") == n.Length - 3).Select(n => File.ReadAllLines(n)).ToList();
            string[] usings = fileZ.ToList().SelectMany(n => n.Where(m => m.StartsWith("using"))).Distinct().ToArray();

            output = String.Join("\n", usings) + "\n";
            fileZ = fileZ.Select(m => m.Where(o => !o.StartsWith("using")).ToArray()).ToList();
            fileZ.ToList().ForEach(n => output += String.Join("\n", n) + "\n");

            Console.WriteLine(output);
        }
    }
}