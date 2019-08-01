using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] param = new double[] { 5, 11, 2};
            double[] result = Tribonacci(param, 1);
            foreach (double db in result)
                Console.WriteLine(db);
        }

        //  1) Square every digit of a number
        public static int SquareDigits(int n)
        {
            string result = "";
            string convertedParameter = n.ToString(); // need to convert into a string the number to manipulate each digit
            foreach (char c in convertedParameter)
            {
                result += Math.Pow(((int)c - 48), 2).ToString(); // converting into ASCII value the character to manipulate it before recasting it into a string
            }
            return int.Parse(result);
        }

        // clever solution : 
        //return int.Parse(String.Concat(n.ToString().Select(a => (int)Math.Pow(char.GetNumericValue(a), 2))));

        // 2) Determine if a number is a square number (the product of a number by itself)
        public static bool IsSquare(int n)
        {
            int i = 0;
            while (i <= n / 2 || i == 1)
            {
                if (i * i == n)
                    return true;
                i++;
            }
            return false;
        }

        // clever solution :
        // return Math.Sqrt(n) % 1 == 0;

        // 3) Tribonacci / the next is the sum of the 3 previous
        public static double[] Tribonacci(double[] signature, int n)
        {
            if (n == 0) return new double[0]; // in case of invalid input
            double next = 0;
            double[] result = new double[n];
            if (n >= 1) // adding the signature array in the solution array, not all the sinature array must be added if n < 3
                result[0] = signature[0];
            if (n >= 2)
                result[1] = signature[1];
            if (n >= 3)
                result[2] = signature[2];
            int i = 3;
            while (i < n)
            {
                // updating the signature array to use it for the new calculated values
                next = signature.Sum();
                signature[0] = signature[1];
                signature[1] = signature[2];
                signature[2] = next;
                result[i] = next;
                i++;
            }
            return result;
        }
    }
}
