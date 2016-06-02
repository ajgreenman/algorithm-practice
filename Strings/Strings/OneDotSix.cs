using System;
using System.Text;

namespace Strings
{
    // Implement a method to perform basic string compression using the counts of repeated characters.
    // For example, the atring aabcccccaaa would become a2b1c5a3. If the "compressed" string would not become
    // smaller than the original string, your method should return the original string. You can assume the
    // string has only uppercase and lowercase letters (a - z).
    public class OneDotSix
    {
        public static void OneDotSix1(string s)
        {
            Console.WriteLine("Performing algorithm 1 for Question 1.6...");

            int letterCount = 0;
            string compressed = "" + s[0];
            char currentCharacter = s[0];

            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == currentCharacter)
                {
                    letterCount++;
                } else
                {
                    compressed += letterCount;
                    letterCount = 1;
                    compressed += s[i];
                    currentCharacter = s[i];
                }
            }

            if(letterCount > 0)
            {
                compressed += letterCount;
            }

            if(s.Length <= compressed.Length)
            {
                compressed = s;
            }

            Console.WriteLine("\"{0}\" will be compressed to \"{1}\"", s, compressed);
        }

        // Instead of doing constant string concatenations (which can be expensive), we use a char array.
        public static void OneDotSix2(string s)
        {
            Console.WriteLine("Performing algorithm 2 for Question 1.6...");

            int letterCount = 0;
            int compressedIndex = 1;
            char[] compressed = new char[s.Length];
            compressed[0] = s[0];
            char currentCharacter = s[0];
            bool tooBig = false;

            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == currentCharacter)
                {
                    letterCount++;
                }
                else
                {
                    if(compressedIndex < compressed.Length)
                    {
                        compressed[compressedIndex] = Convert.ToChar(letterCount + 48);
                        compressedIndex++;
                    }
                    else
                    {
                        tooBig = true;
                        break;
                    }

                    if (compressedIndex < compressed.Length)
                    {
                        compressed[compressedIndex] = s[i];
                        compressedIndex++;
                    }
                    else
                    {
                        tooBig = true;
                        break;
                    }

                    letterCount = 1;
                    currentCharacter = s[i];
                }
            }

            if (letterCount > 0 && compressedIndex < compressed.Length)
            {
                compressed[compressedIndex] = Convert.ToChar(letterCount + 48);
                compressedIndex++;
            }

            if(compressedIndex >= s.Length)
            {
                tooBig = true;
            }

            string retval;
            if(tooBig)
            {
                retval = s;
            }
            else
            {
                retval = new string(compressed);
            }

            Console.WriteLine("\"{0}\" will be compressed to \"{1}\"", s, retval);
        }

        // Instead of doing dumb things with char arrays, I use a StringBuilder.
        public static void OneDotSix3(string s)
        {
            Console.WriteLine("Implementing algorithm 3 of Question 1.6...");

            int letterCount = 0;
            StringBuilder compressed = new StringBuilder();
            
            for(int i = 0; i < s.Length; i++)
            {
                letterCount++;

                if(i + 1 >= s.Length || s[i] !=  s[i + 1])
                {
                    compressed.Append(s[i]);
                    compressed.Append(letterCount);
                    letterCount = 0;
                }
            }

            string retval = compressed.ToString();
            if(retval.Length >= s.Length)
            {
                retval = s;
            }

            Console.WriteLine("\"{0}\" will be compressed to \"{1}\"", s, retval);
        }

        // This algorithm goes through the string twice: Once to check the compressed length (without doing compression), 
        // and once to do the compressing. If the compressed length from the first loop is greater than the original string
        // length, we break early and return the original string. This algorithm will be better for bad input but slightly
        // worse for good input (it will still be O(N) time).
        public static void OneDotSix4(string s)
        {
            Console.WriteLine("Implementing algorithm 4 of Question 1.6...");

            int finalLength = CountCompression(s);
            if(finalLength > s.Length)
            {
                Console.WriteLine("\"{0}\" will be compressed to \"{1}\"", s, s);
                return;
            }

            int letterCount = 0;
            StringBuilder compressed = new StringBuilder(finalLength);

            for (int i = 0; i < s.Length; i++)
            {
                letterCount++;

                if (i + 1 >= s.Length || s[i] != s[i + 1])
                {
                    compressed.Append(s[i]);
                    compressed.Append(letterCount);
                    letterCount = 0;
                }
            }

            Console.WriteLine("\"{0}\" will be compressed to \"{1}\"", s, compressed.ToString());
        }

        private static int CountCompression(string s)
        {
            int finalLength = 0;
            int letterCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                letterCount++;

                if (i + 1 >= s.Length || s[i] != s[i + 1])
                {
                    finalLength += 1 + letterCount.ToString().Length;
                    letterCount = 0;
                }
            }

            return finalLength;
        }
    }
}
