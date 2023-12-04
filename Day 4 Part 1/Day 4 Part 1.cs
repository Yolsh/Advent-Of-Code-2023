using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Day_4_Part_1
{
    internal class Program
    {
        static int[] WinningNumAll(string line)
        {
            int[] WinningNums = new int[10];
            int pointer = 0;
            for (int i = 10; i < 38; i+=3)
            {
                WinningNums[pointer] = int.Parse(line[i] + line[i+1].ToString());
                pointer++;
            }
            return WinningNums;
        }

        static int[] OurNumAll(string line)
        {
            int[] OurNums = new int[25];
            int pointer = 0;
            for(int i = 42; i < line.Length - 1; i += 3)
            {
                OurNums[pointer] = int.Parse(line[i] + line[i + 1].ToString());
                pointer++;
            }
            return OurNums;
        }

        static int compare(string line)
        {
            int[] WinningNums = WinningNumAll(line);
            int[] OurNums = OurNumAll(line);
            int matches = 0;
            int Points = 0;

            foreach(int num in WinningNums)
            {
                if (OurNums.Contains(num))
                {
                    matches++;
                }
            }
            if (matches == 1)
            {
                Points = 1;
            }
            else if (matches > 1)
            {
                Points = 1;
                Points = Points * (int)Math.Pow(2, matches - 1);
            }
            else
            {
                Points = 0;
            }

            foreach (int num in WinningNums)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine("");
            foreach (int num in OurNums)
            {
                Console.Write($"{num} ");
            }
            Console.Write($" Matches: {matches}, Points: {Points}");
            return Points;
        }

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
            int sum = 0;
            for (int line = 0; line < file.Count; line++)
            {
                sum += compare(file[line]);
                Console.WriteLine("\n");
            }
            Console.WriteLine($"answer: {sum}");
            Console.ReadKey();
        }
    }
}
