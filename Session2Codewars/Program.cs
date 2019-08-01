using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(find_it(new int[] { 1, 1, 3, 2, 2, 3, 4, 4, 3}));
        }

        // 1) Determine if a word contains the same letter several times
        public static bool IsIsogram(string str)
        {
            string lowerStr = str.ToLower(); // case insensitivity
            foreach(char c in lowerStr)
            {
                if (lowerStr.Remove(lowerStr.IndexOf(c), 1).Contains(c)) // remove the letter we are evaluating with IndexOf, and then searching if this letter appears agian in the word
                    return false;
            }
            return true;
        }

        // clever solution :
        // return str.ToLower().Distinct().Count()==str.Length;

        // 2) Determine if a walk brings us to our starting point and lasts 10 minutes exactly (each move = 1 min)
        public static bool IsValidWalk(string[] walk)
        {
            int time = 0;
            int hPosition = 0;
            int vPosition = 0;
            foreach (string str in walk)
            {
                if (str == "n")
                    vPosition--;
                else if (str == "s")
                    vPosition++;
                else if (str == "w")
                    hPosition--;
                else
                    hPosition++;
                time++;
            }
            return vPosition == 0 && hPosition == 0 && time == 10;
        }

        // Give the integer that appears an odd number of times in an array
        public static int find_it(int[] seq)
        {
            int count = 0;
            foreach (int nb1 in seq)
            {
                foreach (int nb2 in seq)
                {
                    if (nb1 == nb2)
                        count++;
                }
                if (count % 2 == 1)
                    return nb1;
                count = 0;
            }
            return 0;
        }

        // clever solution :
        // return seq.GroupBy(x => x).Single(g => g.Count() % 2 == 1).Key;
    }
}
