using InterviewQuestions.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace InterviewQuestions.Chapter1
{
    public class OneDotOne : Question
    {
        public OneDotOne()
            : base(1.1, 1, 3)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            if(arguments.Length < 1 || arguments[0].GetType() != typeof(string))
            {
                throw new ArgumentException("Arguments parameter must contain one string.");
            }

            if(result)
            {
                Console.WriteLine("Algorithm {0}: \"{1}\" has all unique characters.", algorithm, arguments[0]);
            }
            else
            {
                Console.WriteLine("Algorithm {0}: \"{1}\" does not have all unique characters.", algorithm, arguments[0]);
            }
        }

        public bool OneDotOne1(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i].Equals(s[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool OneDotOne2(string s)
        {
            var dictionary = CreateDictionary(s);

            foreach (var kv in dictionary)
            {
                if (kv.Value > 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool OneDotOne3(string s)
        {
            BitArray bitArray = new BitArray(26);

            foreach (var c in s.ToLower())
            {
                var i = c - 'a';
                if (bitArray[i])
                {
                    return false;
                }
                else
                {
                    bitArray[i] = true;
                }
            }

            return true;
        }

        private Dictionary<char, int> CreateDictionary(string s)
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
    }
}