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
            int[] WinningNums = new int[5];
            int pointer = 0;
            for (int i = 8; i < 21; i += 3)
            {
                WinningNums[pointer] = int.Parse(line[i] + line[i + 1].ToString());
                pointer++;
            }
            return WinningNums;
        }

        static int[] OurNumAll(string line)
        {
            int[] OurNums = new int[8];
            int pointer = 0;
            for (int i = 25; i < line.Length - 1; i += 3)
            {
                OurNums[pointer] = int.Parse(line[i] + line[i + 1].ToString());
                pointer++;
            }
            return OurNums;
        }

        static int compare(string line, bool MatchReturn)
        {
            int[] WinningNums = WinningNumAll(line);
            int[] OurNums = OurNumAll(line);
            int matches = 0;
            int Points = 0;

            foreach (int num in WinningNums)
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
                //Console.Write($"{num} ");
            }
            //Console.WriteLine("");
            foreach (int num in OurNums)
            {
                //Console.Write($"{num} ");
            }
            //Console.Write($" Matches: {matches}, Points: {Points}");
            if (MatchReturn)
            {
                return matches;
            }
            return Points;
        }

        static List<string> MakeCopies(List<string> file, string line, int LineNum)
        {
            int matches = compare(line, true);
            List<string> fileNew = new List<string>();
            for (int i = 0; i < file.Count; i++)
            {
                fileNew.Add(file[i]);
            }
            for (int i = 0; i < matches; i++)
            {
                fileNew.Insert(LineNum + i + 1, file[LineNum + i + MatchesLast + 1]);
            }
            MatchesLast = matches;
            return fileNew;
        }

        static void ShowFile(List<string> file)
        {
            foreach (string Line in file)
            {
                Console.WriteLine(Line);
            }
            Console.WriteLine("\n");
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
            for (int line = 0; line < file.Count; line++)
            {
                List<string> fileNew = MakeCopies(file, file[line], line);
                file = new List<string>();
                for (int i = 0; i < fileNew.Count; i++)
                {
                    file.Add(fileNew[i]);
                }
                Console.WriteLine($" file {line}: ");
                ShowFile(file);
            }
            Console.WriteLine($"answer: {file.Count}");
            Console.ReadKey();
        }
    }
}
