using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace Day_3_Part_1
{
    internal class Program
    {
        static int FindNumber(int x, string line)
        {
            string Output = line[x].ToString();
            if (Char.IsNumber(line[x - 1]))
            {
                Output = line[x - 1] + Output;
                if (Char.IsNumber(line[x-2]))
                {
                    Output = line[x - 2] + Output;
                }
            }
            if (Char.IsNumber(line[x + 1]))
            {
                Output += line[x + 1];
                if (Char.IsNumber(line[x + 2]))
                {
                    Output += line[x + 2];
                }
            }
            return int.Parse(Output);
        }

        static int Cont(List<int> ints, int findThis)
        {
            int total = 0;
            for (int i = 0; i < ints.Count; i++) 
            {
                if (ints[i] == findThis)
                {
                    total++;
                }
            }
            return total;
        }

        static int Multiplier(List<int> numbers)
        {
            int total = 1;
            for (int i = 0; i <= numbers.Count - 1; i++)
            {
                if (numbers[i] == 43)
                {

                }
                if (Cont(numbers, numbers[i]) > 1)
                {
                    if (numbers.Count == 2)
                    {
                        numbers.Insert(i, 0);
                    }
                    else
                    {
                        numbers.Insert(i, 1);
                    }
                    numbers.Remove(numbers[i + 1]);
                }
            }
            Console.Write("[");
            foreach (int number in numbers)
            {
                Console.Write($"{number}, ");
            }
            Console.Write("]: ");
            foreach (int number in numbers)
            {
                if (numbers.Count > 1)
                {
                    total *= number;
                }
                else
                {
                    return 0;
                }
            }
            Console.WriteLine($"{ total }");
            return total;
        }

        static bool StarFinder(char charecter)
        {
            if (charecter == '*')
            {
                return true;
            }
            return false;
        }

        static int Collector(List<string> file, int CharNum, int LineNum)
        {
            List<int> numbersFound = new List<int>();
            if (CharNum > 0 && CharNum < 139)
            {
                if (LineNum > 0 && LineNum < 139)
                {
                    if (Char.IsNumber(file[LineNum - 1][CharNum - 1]))
                    {
                        numbersFound.Add(FindNumber(CharNum - 1, file[LineNum - 1]));
                    }
                    if (Char.IsNumber(file[LineNum - 1][CharNum]))
                    {
                        numbersFound.Add(FindNumber(CharNum, file[LineNum - 1]));
                    }
                    if (Char.IsNumber(file[LineNum - 1][CharNum + 1]))
                    {
                        numbersFound.Add(FindNumber(CharNum + 1, file[LineNum - 1]));
                    }
                    if (Char.IsNumber(file[LineNum][CharNum - 1]))
                    {
                        numbersFound.Add(FindNumber(CharNum - 1, file[LineNum]));
                    }
                    if (Char.IsNumber(file[LineNum][CharNum + 1]))
                    {
                        numbersFound.Add(FindNumber(CharNum + 1, file[LineNum]));
                    }
                    if (Char.IsNumber(file[LineNum + 1][CharNum - 1]))
                    {
                        numbersFound.Add(FindNumber(CharNum - 1, file[LineNum + 1]));
                    }
                    if (Char.IsNumber(file[LineNum + 1][CharNum]))
                    {
                        numbersFound.Add(FindNumber(CharNum, file[LineNum + 1]));
                    }
                    if (Char.IsNumber(file[LineNum + 1][CharNum + 1]))
                    {
                        numbersFound.Add(FindNumber(CharNum + 1, file[LineNum + 1]));
                    }
                }
            }
            Console.Write($"{ LineNum }: ");
            return Multiplier(numbersFound);
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
            for (int y = 0; y < file.Count; y++)
            {
                for(int x = 0; x < file[y].Length; x++)
                {
                    char charecter = file[y][x];
                    if (StarFinder(charecter))
                    {
                        sum += Collector(file, x, y);
                    }
                }
            }
            Console.WriteLine($" Answer: {sum}");
            Console.ReadKey();
        }
    }
}
