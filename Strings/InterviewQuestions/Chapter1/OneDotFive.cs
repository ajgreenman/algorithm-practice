using InterviewQuestions.Infrastructure;
using System;
using System.Text;

namespace InterviewQuestions.Chapter1
{
    public class OneDotFive : Question
    {
        public OneDotFive()
            : base(1.5, 2, 2)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            if (arguments.Length < 2 || arguments[0].GetType() != typeof(string) || arguments[1].GetType() != typeof(string))
            {
                throw new ArgumentException("Arguments parameter must contain two strings.");
            }

            if (result)
            {
                Console.WriteLine("\"{0}\" and \"{1}\" are one or less edits away from each other.", arguments[0], arguments[1]);
            }
            else
            {
                Console.WriteLine("\"{0}\" and \"{1}\" are more than one edit away from each other.", arguments[0], arguments[1]);
            }
        }

        public bool OneDotFive1(string a, string b)
        {
            if (a.Equals(b))
            {
                return true;
            }

            if (a.Length == b.Length)
            {
                StringBuilder sbA = new StringBuilder(a);
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        sbA[i] = b[i];
                        return sbA.ToString().Equals(b);
                    }
                }
            }
            else
            {
                if (Math.Abs(a.Length - b.Length) > 1)
                {
                    return false;
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
                            return a.ToString().Equals(sbB);
                        }

                        StringBuilder sbA = new StringBuilder(a);
                        sbA.Remove(i, 1);
                        return sbA.ToString().Equals(b);
                    }
                }
            }

            return true;
        }

        public bool OneDotFive2(string a, string b)
        {
            // If the difference in length is more than one than return false.
            if (Math.Abs(a.Length - b.Length) > 1)
            {
                return false;
            }

            string longerString = a.Length > b.Length ? a : b;
            string shorterString = a.Length <= b.Length ? a : b;

            int iLong = 0, iShort = 0;

            bool foundDifference = false;

            while (iShort < shorterString.Length && iLong < longerString.Length)
            {
                if (longerString[iLong] != shorterString[iShort])
                {
                    if (foundDifference)
                    {
                        // This means we found a second difference and we return false.
                        return false;
                    }

                    foundDifference = true; // This marks our first difference.

                    if (shorterString.Length == longerString.Length)
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

            return true;
        }
    }
}
