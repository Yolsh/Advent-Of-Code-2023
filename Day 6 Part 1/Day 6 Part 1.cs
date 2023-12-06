using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Day_6_Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Times = new List<int>();
            List<int> Dist = new List<int>();
            List<string> file = new List<string>();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while(!sr.EndOfStream)
                {
                    file.Add(sr.ReadLine());
                }
            }
            Times = GetNums(file[0]);
            Dist = GetNums(file[1]);
            int total = 1;
            for (int i = 0; i < Times.Count; i++)
            {
                List<int> temp = new List<int>();
                temp = CompTimes(Times[i], Dist[i]);
                total *= temp.Count;
            }
            Console.WriteLine($"Answer: {total}");
            Console.ReadKey();
        }

        static List<int> GetNums(string lineOne)
        {
            List<int> output = new List<int>();
            Regex re = new Regex(@"[0-9]+");
            MatchCollection AllMatches = re.Matches(lineOne);
            foreach (Match match in AllMatches)
            {
                output.Add(int.Parse(match.ToString()));
            }
            return output;
        }

        static List<int> CompTimes(int time, int Dist)
        {
            List<int> output = new List<int>();
            Console.Write($"({time}, {Dist}): ");
            for (int i = 0; i <= time; i++)
            {
                if ((time - i) * i > Dist)
                {
                    output.Add(i);
                    Console.Write($"{i}, ");
                }
            }
            Console.WriteLine();
            return output;
        }
    }
}
