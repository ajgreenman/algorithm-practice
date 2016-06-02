using System;
using System.Text;

namespace Strings
{
    // There are three types of edits that can be performed on strings; insert a character, remove a character,
    // or replace a character. Given two strings, write a function to check if they are one edit (or zero edits) away.
    // pie -> pit
    // pie -> pike
    // pie -> pi
    public static class OneDotFive
    {
        public static void OneDotFive1(string a, string b)
        {
            Console.WriteLine("Performing algorithm 1 for Question 1.5...");

            if (a.Equals(b))
            {
                Console.WriteLine(OneDotFiveValid(true, a, b));
                return;
            }

            if (a.Length == b.Length)
            {
                StringBuilder sbA = new StringBuilder(a);
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        sbA[i] = b[i];
                        Console.WriteLine(OneDotFiveValid(sbA.ToString().Equals(b), a, b));
                        break;
                    }
                }
            }
            else
            {
                if (Math.Abs(a.Length - b.Length) > 1)
                {
                    Console.WriteLine(OneDotFiveValid(false, a, b));
                }

                int shortLength = a.Length <= b.Length ? a.Length : b.Length;

                for (int i = 0; i < shortLength; i++)
                {
                    if (a[i] != b[i])
                    {
                        if (a.Length == shortLength)
                        {
                            StringBuilder sbB = new StringBuilder(b);
                            sbB.Remove(i, 1);
                            Console.WriteLine(OneDotFiveValid(a.Equals(sbB.ToString()), a, b));
                            return;
                        }

                        StringBuilder sbA = new StringBuilder(a);
                        sbA.Remove(i, 1);
                        Console.WriteLine(OneDotFiveValid(sbA.ToString().Equals(b), a, b));
                        return;
                    }
                }

                Console.WriteLine(OneDotFiveValid(true, a, b));
            }
        }

        public static void OneDotFive2(string a, string b)
        {
            Console.WriteLine("Performing algorithm 2 for Question 1.5...");

            // If the difference in length is more than one than return false.
            if(Math.Abs(a.Length - b.Length) > 1)
            {
                Console.WriteLine(OneDotFiveValid(false, a, b));
                return;
            }

            string longerString = a.Length > b.Length ? a : b;
            string shorterString = a.Length <= b.Length ? a : b;

            int iLong = 0, iShort = 0;

            bool foundDifference = false;

            while(iShort < shorterString.Length && iLong < longerString.Length)
            {
                if(longerString[iLong] != shorterString[iShort])
                {
                    if(foundDifference)
                    {
                        // This means we found a second difference and we return false.
                        Console.WriteLine(OneDotFiveValid(false, a, b));
                        return;
                    }

                    foundDifference = true; // This marks our first difference.

                    if(shorterString.Length == longerString.Length)
                    {
                        // If the second string is the same we increment to keep them lined up.
                        // Otherwise we don't which should line up the remaining characters of both strings (making them the same length).
                        iShort++;
                                  
                    }
                }
                else
                {
                    // If there is no difference then we increment the short to keep it matched with the long.
                    iShort++;
                }

                iLong++; // Always increment the longer string.
            }

            Console.WriteLine(OneDotFiveValid(true, a, b));
        }

        private static string OneDotFiveValid(bool valid, string a, string b)
        {
            if (valid)
            {
                return string.Format("True! String \"{0}\" and string \"{1}\" are one or less edits away from each other.", a, b);
            }
            else
            {
                return string.Format("False! String \"{0}\" and string \"{1}\" are more than one edit away from each other.", a, b);
            }
        }
    }
}
