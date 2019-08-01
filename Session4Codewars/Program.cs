using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session4Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2));
        }

        // 1) Replace a character by '(' if it appears 1 time, relace it by ')' otherwise.
        public static string DuplicateEncode(string word)
        {
            string result = "";
            int count = 0;
            foreach (char c1 in word.ToLower()) // Use of ToLower to ignore the case
            {
                foreach (char c2 in word.ToLower())
                {
                    if (c1 == c2)
                        count++;
                }
                if (count > 1) // If the letter appears several times in the word
                    result += ')';
                else
                    result += '(';
                count = 0;
            }
            return result;
        }

        // clever solution :
        // return new string(word.ToLower().Select(ch => word.ToLower().Count(innerCh => ch == innerCh) == 1 ? '(' : ')').ToArray());


        // 2) Return the first longest string consisting of k strings taken in the array.

        public static String LongestPossible(string[] strarr, int k)
        {
            string result = "";
            while (k > 0) // Concatenate k times the longest word. When a word is concatened, it is ignored the next research of the longest word
            {
                int i = 0;
                int maxPos = 0; // Position of the longest word
                while (i < strarr.Length)
                {
                    if (strarr[i].Length > strarr[maxPos].Length) // Current word longest than previous words?
                        maxPos = i;
                    i++;
                }
                result += strarr[maxPos]; // Concatenate the result we got with the new longest word of the array
                k--;
                strarr[maxPos] = ""; // Reinitialize the longest word, he will no longer be the longest word in the next iterations
            }
            return result;
        }

        // 3) Return the first longest string consisting of k CONSECUTIVE strings taken in the array.

        public static string LongestConsec(string[] strarr, int k)
        {
            if (strarr.Length == 0 || strarr.Length < k || k <= 0) // Invalid input conditions
                return "";
            int i = 0;
            string maxString = "";
            while (i < strarr.Length)
            {
                string combinedString = "";
                combinedString = strarr[i]; // Starting point, we will move it from 1 each iteration
                int y = 1;
                while (y < k && y < strarr.Length - i) // Avoid overflow exceptions
                {
                    combinedString += strarr[i + y]; // Adding k words (intermediate counter)
                    y++;
                }
                if (combinedString.Length > maxString.Length) // Testing the longest concatenation
                    maxString = combinedString;
                i++;
            }
            return maxString;
        }

        // clever solution
        //return s.Length==0||s.Length<k||k<=0 ? "" 
        //     : Enumerable.Range(0,s.Length-k+1)
        //                 .Select(x=>string.Join("", s.Skip(x).Take(k)))
        //                 .OrderByDescending(x=>x.Length)
        //                 .First();
    }


}

