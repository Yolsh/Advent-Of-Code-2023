using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day_1_part_1
{
    internal class Program
    {
        static string replace(string word)
        {
            word = word.Replace("oneight", "18");
            word = word.Replace("twone", "21");
            word = word.Replace("eightwo", "82");
            word = word.Replace("eighthree", "83");
            word = word.Replace("threeight", "38");
            word = word.Replace("fiveight", "58");
            word = word.Replace("sevenine", "79");
            word = word.Replace("one", "1");
            word = word.Replace("two", "2");
            word = word.Replace("three", "3");
            word = word.Replace("four", "4");
            word = word.Replace("five", "5");
            word = word.Replace("six", "6");
            word = word.Replace("seven", "7");
            word = word.Replace("eight", "8");
            word = word.Replace("nine", "9");
            return word;
        }
        static int comp(string word)
        {
            string output = "";
            foreach(char letter in word)
            {
                try
                {
                    int.Parse(letter.ToString());
                    output += letter;
                }
                catch { }
            }
            if (output.Length == 1) 
            {
                output = output[0] + output[0].ToString();
            }
            else
            {
                output = output[0] + output[output.Length - 1].ToString();
            }
            Console.WriteLine(output);
            return int.Parse(output);
        }
        static void Main(string[] args)
        {
            List<string> file = new List<string>();
            int sum = 0;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    file.Add(sr.ReadLine());
                }
            }
            for (int i = 0; i < file.Count; i++)
            {
                Console.Write(i + ": ");
                sum += comp(replace(file[i]));
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
