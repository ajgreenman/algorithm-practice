using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public static class CommonStringAlgorithms
    {
        // This algorithm takes in a string and returns a bit vector of its characters.
        // It only allows letters and is not case sensitive.
        public static int GetBitVector(string s)
        {
            int bitVector = 0;

            foreach (char c in s.ToLower())
            {
                int i = c - 'a';
                if (i >= 0 && i < 'z' - 'a')
                {
                    bitVector |= 1 << i;
                }
            }

            return bitVector;
        }

        public static bool AreBitVectorsOffByOneOrLessBit(int bvA, int bvB)
        {
            if (bvA - bvB == 0)
            {
                return true;
            }

            int bitDifferences = bvA & ~bvB;

            return (bitDifferences & (bitDifferences - 1)) == 0;
        }

        public static int[] GetCharCount(string s)
        {
            int[] count = new int[26];

            foreach (char c in s.ToLower())
            {
                int i = c - 'a';
                if (i >= 0 && i < 26)
                {
                    count[i]++;
                }
            }

            return count;
        }
    }
}
