using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day_2_Part_1
{
    internal class Program
    {
        static string[] numfind(string line, int[] ans)
        {
            string[] colours = new string[line.Length];
            for (int i = line.IndexOf(":"); i < line.Length; i++)
            {
                string letter = line[i].ToString();
                if (letter == ";")
                {
                    colours[i] = ";";
                }
                if (Char.IsNumber(line[i]))
                {
                    ans[i] = int.Parse(letter);
                    if (Char.IsNumber(line[i + 1]))
                    {
                        ans[i] = ans[i] * 10;
                        ans[i] += int.Parse(line[i + 1].ToString());
                        colours[i] = line[i + 3].ToString();
                        i++;
                    }
                    else { colours[i] = line[i+2].ToString(); }
                }
            }
            int j = 0;
            foreach(int num in ans)
            {
                if (num != 0)
                {
                    Console.Write(num);
                    Console.Write(" : " + colours[j] + ", ");
                }
                j++;
            }
            Console.WriteLine("");
            return colours;
        }

        static bool comparison(string line)
        {
            List<int> redtot = new List<int>();
            List<int> greentot = new List<int>();
            List<int> bluetot = new List<int>();
            redtot.Add(0);
            greentot.Add(0);
            bluetot.Add(0);
            int[] answers = new int[line.Length];
            string[] colours = new string[line.Length];


            colours = numfind(line, answers);

            int i = 0;
            int answer_pointer = 0;
            foreach(string colour in colours)
            {
                if (colour == ";")
                {
                    answer_pointer++;
                    redtot.Add(0);
                    greentot.Add(0);
                    bluetot.Add(0);
                }
                if (colour == "r")
                {
                    redtot[answer_pointer] += answers[i];
                }
                else if (colour == "g")
                {
                    greentot[answer_pointer] += answers[i];
                }
                else if (colour == "b")
                {
                    bluetot[answer_pointer] += answers[i];
                }
                i++;
            }
            Console.WriteLine(redtot + ", " + bluetot + ", " + greentot);
            if(redtot.Max() <= 12 && greentot.Max() <= 13 && bluetot.Max() <= 14)
            {
                return true;
            }
            return false;
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
            int i = 0;
            foreach (string line in file)
            {
                i++;
                Console.Write("line " + i + ": ");
                if (comparison(line))
                {
                    sum += i;
                    Console.WriteLine("yes");
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
