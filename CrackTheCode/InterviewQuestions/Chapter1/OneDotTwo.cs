using System;
using InterviewQuestions.Infrastructure;
using System.Linq;

namespace InterviewQuestions.Chapter1
{
    public class OneDotTwo : Question
    {
        public OneDotTwo()
            : base(1.2, 2, 3)
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
                Console.WriteLine("Algorithm {0}: \"{1}\" and \"{2}\" are permutations.", algorithm, arguments[0], arguments[1]);
            }
            else
            {
                Console.WriteLine("Algorithm {0}: \"{1}\" and \"{2}\" are not permutations.", algorithm, arguments[0], arguments[1]);
            }
        }

        public bool OneDotTwo1(string a, string b)
        {
            return string.Concat(a.OrderBy(c => c)).Equals(string.Concat(b.OrderBy(c => c)));
        }

        // This solution may be worse than solution 1, but it's good practice.
        public bool OneDotTwo2(string a, string b)
        {
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
                    return false;
                }
            }

            return true;
        }

        // This is a faster version of solution 2. Probably more efficient than solution 1 but more complicated.
        public bool OneDotTwo3(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            int[] counter = new int[256]; // Number of allowed characters (Case-sensitive!).

            foreach (var c in a)
            {
                counter[c]++;
            }

            foreach (var c in b)
            {
                counter[c]--;
                if (counter[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
