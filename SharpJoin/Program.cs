//Disclaimers 'n'stuff
/*
MIT License

Copyright (c) 2017 Martin Gerstenmaier

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

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
            string[] usings = fileZ.SelectMany(n => n.Where(m => m.StartsWith("using"))).Distinct().ToArray();

            output = String.Join("\n", usings) + "\n";
            fileZ = fileZ.Select(m => m.Where(o => !o.StartsWith("using")).ToArray()).ToList();
            fileZ.ForEach(n => output += String.Join("\n", n) + "\n");

            Console.WriteLine(output);
        }
    }
}