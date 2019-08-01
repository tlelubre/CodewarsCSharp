using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session3Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int>() { 1, 2, 3 };
            List<int> test2 = new List<int>() { 1, 2, 3, 4 };
            List<int> test3 = test2.Except(test).ToList();
            foreach (int nb in test3)
                Console.WriteLine(nb);

        }

        // 1) Determine the max and min number in a string, where each number is separated by a white space
        public static string HighAndLow(string numbers)
        {
            int[] intNumbers = numbers.Split(' ').Select(x => int.Parse(x)).ToArray(); // need to cast items into integers to define the max and the min values, select help us to browse items one by one and cast them
            string max = intNumbers.Max().ToString();
            string min = intNumbers.Min().ToString();
            return max + ' ' + min;
        }

        /*
         * clever solution :
         *  var parsed = numbers.Split().Select(int.Parse);
            return parsed.Max() + " " + parsed.Min();
         */


        // 2) Find the next perfect square
        public static long FindNextSquare(long num)
        {
            double sqrt = Math.Sqrt(num); // need the variable to be a double or the number will be rounded and the test will be false
            if (sqrt % 1 > 0) // modulo = rest of the entire division, so a float nb % 1 will be greater than 0
                return -1;
            return (long)Math.Pow(sqrt + 1, 2); // need to cast because the fct returns a long
        }

        // clever solution :
        // return Sqrt(num) % 1 == 0 ? (long)Pow(Sqrt(num) + 1, 2) : -1;

        // Remove the smallest nb
        public static List<int> RemoveSmallest(List<int> numbers)
        {
            if (numbers.Count == 0) return new List<int>();
            int invalidIndex = numbers.IndexOf(numbers.Min()); // the first occurence we have to delete (! if there are several mins)
            int i = 0;
            List<int> result = new List<int>();
            while (i < numbers.Count())
            {
                if (i != invalidIndex)
                    result.Add(numbers[i]);
                i++;
            }
            return result;
        }

        // clever solution :
        //if (numbers.Count > 0)
        //{
        //    numbers.Remove(numbers.Min());
        //}
        //return numbers;
    }
}
