using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Day_3_Part_1
{
    internal class Program
    {
        static char[] ops = { '$', '%', '&', '*', '@', '#', '=', '+', '-', '/', };

        static int findNum(string line, ref int i)
        {
            string numFinal = line[i].ToString();
            if (Char.IsNumber(line[i - 1]))
            {
                if (Char.IsNumber(line[i - 2]))
                {
                    numFinal = line[i - 2].ToString() + line[i - 1].ToString() + numFinal;
                }
                else
                {
                    numFinal = line[i - 1] + numFinal;
                }
            }
            if (Char.IsNumber(line[i + 1]))
            {
                numFinal += line[i+1];
                if (Char.IsNumber(line[i + 2]))
                {
                    numFinal += line[i+2];
                    i += 2;
                }
                else
                {
                    i++;
                }
            }
            if (numFinal != "")
            {
                return int.Parse(numFinal);
            }
            else
            {
                return 0;
            }
        }
        static int adjacentCheck(char charecter, string line, ref int j, string surround)
        {
            if (Char.IsNumber(charecter))
            {
                foreach (char potentialOps in surround)
                {
                    foreach (char op in ops)
                    {
                        if (potentialOps == op)
                        {
                            int output = findNum(line, ref j);
                            Console.Write($" {output}");
                            return output;
                        }
                    }
                }
            }
            return 0;
        }

        static string surrounding(List<string> file, int i, int j)
        {
            string output = "";
            if (i > 0)
            {
                if (j > 0)
                {
                    output += file[i - 1][j - 1];
                }
                output += file[i - 1][j];
                if (j < 139)
                {
                    output += file[i - 1][j + 1];
                }
            }
            if (j > 0)
            {
                output += file[i][j - 1];
            }
            if (j < 139)
            {
                output += file[i][j + 1];
            }
            if (i < 139)
            {
                if (j > 0)
                {
                    output += file[i + 1][j - 1];
                }
                output += file[i + 1][j];
                if (j < 139)
                {
                    output += file[i + 1][j + 1];
                }
            }
            return output;
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
            for (int i = 0; i < file.Count; i++)
            {
                for (int j = 0; j < file[i].Length; j++)
                {
                    sum += adjacentCheck(file[i][j], file[i], ref j, surrounding(file, i, j));
                }
            }
            Console.WriteLine($" Answer: {sum}");
            Console.ReadKey();
        }
    }
}
