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
        struct ret
        {
            public int[] first;
            public int[] last;
        }
        static ret WordConvert(string word)
        {
            ret final;
            final.first = new int[2];
            final.last = new int[2];
            List<string> values = new List<string>();
            List<int> indexes = new List<int>();
            if (word.Contains("one"))
            {
                values.Add("1");
                indexes.Add(word.IndexOf("one"));
            }
            if (word.Contains("two"))
            {
                values.Add("2");
                indexes.Add(word.IndexOf("two"));
            }
            if (word.Contains("three"))
            {
                values.Add("3");
                indexes.Add(word.IndexOf("three"));
            }
            if (word.Contains("four"))
            {
                values.Add("4");
                indexes.Add(word.IndexOf("four"));
            }
            if (word.Contains("five"))
            {
                values.Add("5");
                indexes.Add(word.IndexOf("five"));
            }
            if (word.Contains("six"))
            {
                values.Add("6");
                indexes.Add(word.IndexOf("six"));
            }
            if (word.Contains("seven"))
            {
                values.Add("7");
                indexes.Add(word.IndexOf("seven"));
            }
            if (word.Contains("eight"))
            {
                values.Add("8");
                indexes.Add(word.IndexOf("eight"));
            }
            if (word.Contains("nine"))
            {
                values.Add("9");
                indexes.Add(word.IndexOf("nine"));
            }
            final.first[0] = indexes.Min().ToString();
            final.first[1] = values[indexes.IndexOf(int.Parse(final.first[0]))];
            final.last[0] = indexes.Max().ToString();
            final.first[1] = values[indexes.IndexOf(int.Parse(final.last[0]))];
            return final;
        }
        static ret findNum(string word)
        {
            List<string> values = new List<string>();
            List<int> indexes = new List<int>();

            for (int i = 0; i < word.Length; i++)
            {
                try
                {
                    int.Parse(word[i].ToString());
                    values.Add(word[i].ToString());
                    indexes.Add(i);
                }
                catch { }
            }
            ret final;
            final.first = new string[2];
            final.last = new string[2];
            final.first[0] = indexes.Min().ToString();
            final.first[1] = values[indexes.IndexOf(int.Parse(final.first[0]))];
            final.last[0] = indexes.Max().ToString();
            final.first[1] = values[indexes.IndexOf(int.Parse(final.last[0]))];

            return final;
        }
        static int comp(string word)
        {
            if (findNum(word).first[0] > WordConvert(word).first[0])

                if (output.Length == 1)
                {
                    output += output;
                }
                else if (output.Length > 2)
                {
                    output = output[0] + output[output.Length - 1].ToString();
                }
            Console.WriteLine(output);
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
                Console.WriteLine(WordConvert(file[i]));
                sum += comp(file[i]);
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
