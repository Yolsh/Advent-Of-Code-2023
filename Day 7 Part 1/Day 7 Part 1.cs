using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_7_Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> file = new List<string>();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while(!sr.EndOfStream)
                {
                    file.Add(sr.ReadLine());
                }
            }
            Console.ReadKey();
        }
    }
}
