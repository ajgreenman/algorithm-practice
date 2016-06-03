using InterviewQuestions.Infrastructure;
using System;

namespace InterviewQuestions.Chapter1
{
    public class OneDotThree : Question
    {
        private string _transformed = "";

        public OneDotThree()
            : base(1.3, 1, 2)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            if (arguments.Length < 1 || arguments[0].GetType() != typeof(string))
            {
                throw new ArgumentException("Arguments parameter must contain one string.");
            }

            if(!_transformed.Equals(""))
            {
                Console.WriteLine("Algorithm {0}: Old - \"{1}\" New - \"{2}\"", algorithm, arguments[0], _transformed);
            }
            else
            {
                Console.WriteLine("Algorithm {0} failed.", algorithm);
            }
        }

        public void OneDotThree1(string phrase)
        {
            _transformed = "";

            int phraseLength = GetLength(phrase);

            char[] newPhrase = new char[phraseLength];
            for (int i = 0, j = 0; i < phrase.Length; i++, j++)
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

            _transformed = new string(newPhrase);
        }

        public void OneDotThree2(string phrase)
        {
            _transformed = "";

            int spaceCount = 0;
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == ' ')
                {
                    spaceCount++;
                }
            }

            // This is correct code but not in .NET. You can't edit strings like that. In other languages it's valid.
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
        }

        private int GetLength(string phrase)
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
