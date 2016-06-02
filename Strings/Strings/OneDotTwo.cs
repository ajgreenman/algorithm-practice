using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    // Given two strings, write a method to decide if one is a permutation of the other.
    public class OneDotTwo
    {
        public static void OneDotTwo1(string a, string b)
        {
            Console.WriteLine("Performing algorithm 1 for Question 1.2...");
            
            if (String.Concat(a.OrderBy(c => c)).Equals(String.Concat(b.OrderBy(c => c))))
            {
                Console.WriteLine("\n'{0}' and '{1}' are permutations of each other.\n", a, b);
            }
            else
            {
                Console.WriteLine("\n'{0}' and '{1}' are not permutations of each other.\n", a, b);
            }
        }

        public static void OneDotTwo2(string a, string b)
        {
            // This solution may be worse than solution 1, but it's good practice.
            Console.WriteLine("Performing algorithm 2 for Question 1.2...");

            int[] counterA = new int[256]; // Number of allowed characters (Case-sensitive!).
            int[] counterB = new int[256]; // Number of allowed characters (Case-sensitive!).
            foreach (var c in a)
            {
                counterA[c]++;
            }

            foreach (var c in b)
            {
                counterB[c]++;
            }

            for (int i = 0; i < 256; i++)
            {
                if (counterA[i] != counterB[i])
                {
                    Console.WriteLine("\n'{0}' and '{1}' are not permutations of each other.\n", a, b);
                }
            }

            Console.WriteLine("\n'{0}' and '{1}' are permutations of each other.\n", a, b);
        }

        public static void OneDotTwo3(string a, string b)
        {
            // This is a faster version of solution 2. Probably more efficient than solution 1 but more complicated.
            Console.WriteLine("Performing algorithm 3 for Question 1.2...");

            if (a.Length != b.Length)
            {
                Console.WriteLine("\n'{0}' and '{1}' are not permutations of each other.\n", a, b);
                return;
            }

            int[] counter = new int[256]; // Number of allowed characters.

            foreach (var c in a)
            {
                counter[c]++;
            }

            foreach (var c in b)
            {
                counter[c]--;
                if (counter[c] < 0)
                {
                    Console.WriteLine("\n'{0}' and '{1}' are not permutations of each other.\n", a, b);
                    return;
                }
            }

            Console.WriteLine("\n'{0}' and '{1}' are permutations of each other.\n", a, b);
        }
    }
}
