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
        static List<int> GetSeedNums(string Line)
        {
            List<int> output = new List<int>();
            Regex re = new Regex("\\d+");
            MatchCollection match = re.Matches(Line);
            foreach (Match num in match)
            {
                output.Add(int.Parse(num.ToString()));
            }
            return output;
        }
        static List<List<int>> FindMap(List<string> Lines)
        {
            string input = "";
            foreach (string Line in Lines)
            {
                input += Line;
                input += " ";
            }
            List<List<int>> output = new List<List<int>>();
            Regex re = new Regex(@"\d+\s");
            MatchCollection Allmatches = re.Matches(input);
            for(int i = 0; i < Allmatches.Count; i+=3)
            {
                List<int> temp = new List<int> { int.Parse(Allmatches[i].ToString()), int.Parse(Allmatches[i + 1].ToString()), int.Parse(Allmatches[i + 2].ToString()) };
                output.Add(temp);
            }
            return output;
        }

        static int ApplyMap(List<List<List<int>>> Maps, int seed) // this will need modifying as it probs doesnt work
        {
            int Location = seed;
            foreach (List<List<int>> Map in Maps)
            {
                foreach (List<int> points in Map)
                {
                    bool modify = false;
                    for (int i = 0; i < points[2]; i++)
                    {
                        if (Location == points[1] + i)
                        {
                            Location = points[1] + i;
                            Console.Write($"{seed}: {Location}, ");
                        }
                        else if (Location >= points[0] + i)
                        {
                            modify = true;
                            Console.Write($"{seed}: {Location}, ");
                        }
                    }
                    if (modify)
                    {
                        Location += points[2];
                    }
                }
            }
            return Location;
        }

        static void Main(string[] args)
        {
            List<string> file = new List<string>();
            List<int> seedNums = new List<int>();
            List<string> map = new List<string>();
            List<List<List<int>>> Maps = new List<List<List<int>>>();
            List<int> Locations = new List<int>();
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
                if (file[LineNum] == "" && LineNum != 1)
                {
                    Maps.Add(FindMap(map));
                    map.Clear();
                }
            }
            foreach (int seed in seedNums)
            {
                Locations.Add(ApplyMap(Maps, seed));
            }
            Console.WriteLine($"Answer: {Locations.Min()}");
            Console.ReadKey();
        }
    }
}
