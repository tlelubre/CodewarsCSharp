using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session5Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Rot13("Test"));
        }


        // 1) Encrypting and decrypting words. Crypting : Take a letter each 2 letter, concatenete these letters and put the result word at the beginning of the new string. Then take the other letters, concatenate them and concatenate the result with the first concatenated word.
        public static string Encrypt(string text, int n)
        {
            if (text == null || text.Length == 0 || n <= 0) // Handling invalid inputs
                return text;
            string result = text;
            string[] firstLetters = text.Where((x, y) => y % 2 != 0).Select(x => x.ToString()).ToArray(); // Take the odd letters
            string[] secondLetters = text.Where((x, y) => y % 2 == 0).Select(x => x.ToString()).ToArray(); // Take the even letters
            if (n > 0) // How many times we have to encrypt
            {
                string firstString = string.Join("", firstLetters); // Concatenate to get the first part of the word
                string secondString = string.Join("", secondLetters); // Concatenate to get the second part of the word
                result = firstString + secondString; // Final word
                return result = Encrypt(result, n - 1); // Recursive call
            }
            else
                return result;
        }

        public static string Decrypt(string encryptedText, int n)
        {
            if (encryptedText == null || encryptedText.Length == 0 || n <= 0) // Handling invalid inputs
                return encryptedText;
            string result = "";
            while (n > 0)
            {
                result = ""; // Reinitialize the result, it's better to have a clean variable to perform concatenations
                string[] evenLetters = encryptedText.Take(encryptedText.Length / 2).Select(x => x.ToString()).ToArray(); // Sorting the letters. The first letters are the even letters from the initial string
                string[] oddLetters = encryptedText.Skip(encryptedText.Length / 2).Select(x => x.ToString()).ToArray();
                int i = 0;
                int j = 0;
                int k = 0;
                while (i < evenLetters.Count() + oddLetters.Count()) // A word's length = its concatenated elems'length added
                {
                    // Taking a letter in each array, turn by turn
                    if (i % 2 == 0)
                    {
                        result += oddLetters[j];
                        j++;
                    }
                    else
                    {
                        result += evenLetters[k];
                        k++;
                    }
                    i++;
                }
                // Reinitializing variables if we have another decryption to process
                i = 0;
                j = 0;
                k = 0;
                n--;
                encryptedText = result; // If we have another decryption to process, we have to change the word we currently work on
            }
            return result;
        }

        // 2) Make a ROT13

        public static string Rot13(string message)
        {
            string result = "";
            char[] resultArray = message.Select(x => (((int)x >= 97 && x <= 109) || ((int)x >= 65 && (int)x <= 77)) ? (char)((int)x + 13) : (((int)x > 109 && (int)x <= 122) || (int)x > 77 && (int)x <= 90) ? (char)((int)x - 13) : x).ToArray();
            foreach (char c in resultArray)
                result += c;
            return result;
        }

        // clever solution :
        //return String.Join("", message.Select(x => char.IsLetter(x) ? (x >= 65 && x <= 77) || (x >= 97 && x <= 109) ? (char) (x + 13) : (char) (x - 13) : x));
    }
}
