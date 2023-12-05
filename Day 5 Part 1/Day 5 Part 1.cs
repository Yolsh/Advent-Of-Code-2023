using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Day_5_Part_1
{
    internal class Program
    {
        static List<long> GetSeedNums(string Line)
        {
            List<long> output = new List<long>();
            Regex re = new Regex(@"\d+");
            MatchCollection match = re.Matches(Line);
            foreach (Match num in match)
            {
                output.Add(long.Parse(num.ToString()));
            }
            return output;
        }
        static List<List<long>> FindMap(List<string> Lines)
        {
            string input = "";
            foreach (string Line in Lines)
            {
                input += Line;
                input += " ";
            }
            List<List<long>> output = new List<List<long>>();
            Regex re = new Regex(@"\d+\s");
            MatchCollection Allmatches = re.Matches(input);
            for(int i = 0; i < Allmatches.Count; i+=3)
            {
                List<long> temp = new List<long> { long.Parse(Allmatches[i].ToString()), long.Parse(Allmatches[i + 1].ToString()), long.Parse(Allmatches[i + 2].ToString()) };
                output.Add(temp);
            }
            return output;
        }

        static long ApplyMap(List<List<List<long>>> Maps, long seed) // this will need modifying as it probs doesnt work
        {
            long Location = seed;
            foreach (List<List<long>> Map in Maps)
            {
                foreach (List<long> points in Map)
                {
                    if (Location >= points[1] && Location < points[1] + points[2])
                    {
                        Location += points[0] - points[1];
                        Console.Write($"({points[0]}, {points[1]}, {points[2]}): {Location} | ");
                        break;
                    }
                }
            }
            Console.WriteLine($"{seed}: {Location}");
            return Location;
        }

        static void Main(string[] args)
        {
            List<string> file = new List<string>();
            List<long> seedNums = new List<long>();
            List<string> map = new List<string>();
            List<List<List<long>>> Maps = new List<List<List<long>>>();
            List<long> Locations = new List<long>();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    file.Add(sr.ReadLine());
                }
            }
            for (int LineNum = 0; LineNum < file.Count; LineNum++)
            {
                if (file[LineNum].StartsWith("seeds: "))
                {
                    seedNums = GetSeedNums(file[0]);
                }
                else
                {
                    map.Add(file[LineNum]);
                }
                if ((file[LineNum] == "" && LineNum != 1) || LineNum == file.Count-1)
                {
                    Maps.Add(FindMap(map));
                    map.Clear();
                }
            }
            foreach (long seed in seedNums)
            {
                Locations.Add(ApplyMap(Maps, seed));
            }
            Console.WriteLine($"Answer: {Locations.Min()}");
            Console.ReadKey();
        }
    }
}
