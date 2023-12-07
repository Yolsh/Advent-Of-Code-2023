using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;

namespace Day_7_Part_1
{
    internal class Program
    {
        static char[] cardTypes = { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };
        struct card
        {
            public int Length;
            public string cardSet;
            public string fullCard;
        }

        static void Main(string[] args)
        {
            List<string> file = new List<string>();
            List<card> cards = new List<card>();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while(!sr.EndOfStream)
                {
                    file.Add(sr.ReadLine());
                }
            }
            foreach (string line in file)
            {
                cards.Add(HouseFinder(line));
            }
            Console.ReadKey();
        }

        static card HouseFinder(string line)
        {
            card temp = new card(); temp.Length = 0; temp.cardSet = "I"; temp.fullCard = line;
            foreach (char card in cardTypes)
            {
                Regex re = new Regex($"[{card}]+");
                Match match = re.Match(line);
                if (match.ToString().Length > temp.Length)
                {
                    temp.Length = match.ToString().Length;
                    temp.cardSet = match.ToString();
                }
            }
            return temp;
        }

        static int HouseCompare(List<card> cards)
        {
            for (int i = 0; i < cards.Count; i++) 
            {
                if (cards[i].Length < cards[i+1].Length)
                {
                    cards.Insert(i, cards[i+1]);
                    cards.Remove(cards.ElementAt(i+1)); //this may need changing
                    cards.Remove(cards.ElementAt(i + 2));
                }

            }
        }
    }
}
