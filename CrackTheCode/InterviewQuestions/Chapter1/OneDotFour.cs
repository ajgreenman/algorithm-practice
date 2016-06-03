using InterviewQuestions.Infrastructure;
using System;

namespace InterviewQuestions.Chapter1
{
    public class OneDotFour : Question
    {
        public OneDotFour()
            : base(1.4, 1, 2)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            if (arguments.Length < 1 || arguments[0].GetType() != typeof(string))
            {
                throw new ArgumentException("Arguments parameter must contain two strings.");
            }

            if (result)
            {
                Console.WriteLine("Algorithm {0}: \"{1}\" is a permutation of a palindrome.", algorithm, arguments[0]);
            }
            else
            {
                Console.WriteLine("Algorithm {0}: \"{1}\" is not a permutation of a palindrome.", algorithm, arguments[0]);
            }
        }

        public bool OneDotFour1(string s)
        {
            int[] characterCount = new int[26];

            foreach (char c in s.ToLower())
            {
                characterCount[c - 'a']++;
            }

            int oddCount = 0;
            for (int i = 0; i < characterCount.Length; i++)
            {
                if (characterCount[i] % 2 == 1)
                {
                    oddCount++;
                }
            }


            return oddCount < 2;
        }

        // Turns out algorithm 1 is an optimal solution, however there is another that uses a clever trick to use less memory.
        // This algorithm toggles a bit in a bit vector for each character in the string.
        // If a letter's bit is a 0, then it was seen an even number of times.
        // If a letter's bit is a 1, then it was seen an odd number of times.
        public bool OneDotFour2(string s)
        {
            int bitVector = GetBitVector(s);

            return StringIsPalindromePermutation(bitVector);
        }

        private int GetBitVector(string s)
        {
            int bitVector = 0;

            foreach (char c in s.ToLower())
            {
                // Every letter we parse will toggle the bit at the bit of it's character code.
                // Example the letter 'a' will toggle the bit at position 0, 'b' at position 1, and so on.
                bitVector = Toggle(bitVector, c - 'a');
            }

            return bitVector;
        }

        private int Toggle(int bitVector, int characterCode)
        {
            if (characterCode < 0)
            {
                // Invalid letter so we just return the bitVector.
                return bitVector;
            }

            int mask = 1 << characterCode;
            if ((bitVector & mask) == 0)
            {
                // This toggles the bitVector at the bit of the mask from 0 to 1.
                bitVector |= mask;
            }
            else
            {
                // This toggles the bitVector at the bit of the mask from 1 to 0.
                bitVector &= ~mask;
            }

            return bitVector;
        }

        private bool StringIsPalindromePermutation(int bitVector)
        {
            if (bitVector == 0)
            {
                // If the bit vector is equal to 0, then all letters in the string had an even count.
                return true;
            }

            // This funky logic is actually checking to see if only 1 letter in the string had an odd count, and no more.
            // If we subtract 1 from a bitVector with only 1 bit set, then anding them together will result in 0.
            // We can trust this because only bitVectors with 1 bit set behave in this manner.
            return (bitVector & (bitVector - 1)) == 0;
        }
    }
}
