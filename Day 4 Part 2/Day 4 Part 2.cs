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
        static int MatchesLast = 0;
        static int[] WinningNumAll(string line)
        {
            int[] WinningNums = new int[10];
            int pointer = 0;
            for (int i = 10; i < 38; i += 3)
            {
                WinningNums[pointer] = int.Parse(line[i] + line[i + 1].ToString());
                pointer++;
            }
            return WinningNums;
        }

        static int[] OurNumAll(string line)
        {
            int[] OurNums = new int[25];
            int pointer = 0;
            for (int i = 42; i < line.Length - 1; i += 3)
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

            foreach (int num in WinningNums)
            {
                if (OurNums.Contains(num))
                {
                    matches++;
                }
            }

            foreach (int num in WinningNums)
            {
                //Console.Write($"{num} ");
            }
            //Console.WriteLine("");
            foreach (int num in OurNums)
            {
                //Console.Write($"{num} ");
            }
            //Console.Write($" Matches: {matches}, Points: {Points}");
            return matches;
        }

        static int recursiveGames(List<string> file, int LineNum)
        {
            int answer = 0;
            int matches = compare(file[LineNum]);
            for (int i = 0; i < matches; i++)
            {
                answer += recursiveGames(file, LineNum+i+1);
            }
            answer++;
            return answer;
        }

        static void Main(string[] args)
        {
            List<string> file = new List<string>();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    file.Add(sr.ReadLine());
                }
            }
            int sum = 0;
            for(int x = 0; x < file.Count; x++)
            {
                sum += recursiveGames(file, x);
                Console.WriteLine($"Line: {x + 1}");
            }
            Console.WriteLine($"answer: {sum}");
            Console.ReadKey();
        }
    }
}
