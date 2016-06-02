using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class OneDotThree
    {
        public static void OneDotThree1(string phrase)
        {
            Console.WriteLine("Performing algorithm 1 for Question 1.3...");

            int phraseLength = GetLength(phrase);

            char[] newPhrase = new char[phraseLength];
            for(int i = 0, j = 0; i < phrase.Length; i++, j++)
            {
                if (phrase[i] == ' ')
                {
                    newPhrase[j] = '%';
                    j++;
                    newPhrase[j] = '2';
                    j++;
                    newPhrase[j] = '0';
                }
                else
                {
                    newPhrase[j] = phrase[i];
                }
            }

            Console.WriteLine("Old: \"{0}\"\nNew: \"{1}\"", phrase, new string(newPhrase));
        }

        public static void OneDotThree2(string phrase)
        {
            Console.WriteLine("Performing algorithm 2 for Question 1.3...");

            int spaceCount = 0;
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == ' ')
                {
                    spaceCount++;
                }
            }

            //int newLength = phrase.Length + spaceCount * 2;
            //for (int i = phrase.Length - 1; i >= 0; i--)
            //{
            //    if (phrase[i] == ' ')
            //    {
            //        phrase[newLength - 1] = '0';
            //        phrase[newLength - 2] = '2';
            //        phrase[newLength - 3] = '%';
            //        newLength = newLength - 3;
            //    }
            //    else
            //    {
            //        phrase[newLength - 1] = phrase[i];
            //        newLength--;
            //    }
            //}

            Console.WriteLine("This is correct code but not in .NET. You can't edit strings like that. In other languages it's valid.");
        }

        private static int GetLength(string phrase)
        {
            int count = 0;

            foreach (char c in phrase)
            {
                if (c == ' ')
                {
                    count++;
                }
            }

            return (count * 2) + phrase.Length;
        }
    }
}
