using System;
using System.Collections;
using System.Collections.Generic;

namespace Strings
{
    // Implement an algorithm to determine if a string has all unique characters. What if you cannot use any additional data structures?
    // Hint 1: Use a hash-table.
    // Hint 2: Use a bit-vector.
    // Hint 3: Can you write in N log N? (Do a sort and if you have matching characters, return false)
    public static class OneDotOne
    {
        public static void OneDotOne1(string s)
        {
            Console.WriteLine("Performing algorithm 1 for Question 1.1...");

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i].Equals(s[j]))
                    {
                        Console.WriteLine("\nThe string '{0}' does not have unique characters.\nExample: character '{1}' is at both position {2} and position {3}.\n", s, s[i], i, j);
                        return;
                    }
                }
            }
        }

        public static void OneDotOne2(string s)
        {
            Console.WriteLine("Performing algorithm 2 for Question 1.1...");

            var dictionary = CreateDictionary(s);

            foreach (var kv in dictionary)
            {
                if (kv.Value > 1)
                {
                    Console.WriteLine("\nThe string '{0}' does not have unique characters.\nExample: There are {1} '{2}'s.\n", s, kv.Value, kv.Key);
                    return;
                }
            }
        }

        private static Dictionary<char, int> CreateDictionary(string s)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (d.ContainsKey(c))
                {
                    d[c]++;
                }
                else
                {
                    d[c] = 1;
                }
            }

            return d;
        }

        public static void OneDotOne3(string s)
        {
            Console.WriteLine("Performing algorithm 3 for Question 1.1...");

            BitArray bitArray = new BitArray(26);

            foreach (var c in s.ToLower())
            {
                var i = c - 'a';
                if (bitArray[i])
                {
                    Console.WriteLine("\nThe string '{0}' does not have unique characters.\nExample: There are multiple '{1}'s.\n", s, (char)('a' + i));
                    return;
                }
                else
                {
                    bitArray[i] = true;
                }
            }
        }
    }
}
