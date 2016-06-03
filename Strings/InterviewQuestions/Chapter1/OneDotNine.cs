using InterviewQuestions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter1
{
    public class OneDotNine : Question
    {
        public OneDotNine()
            : base(1.9, 2, 2)
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
                Console.WriteLine("Algorithm {0}: \"{1}\" is a rotation of \"{2}.\"", algorithm, arguments[1], arguments[0]);
            }
            else
            {
                Console.WriteLine("Algorithm {0}: \"{1}\" is not a rotation of \"{2}.\"", algorithm, arguments[1], arguments[0]);
            }
        }
        public bool OneDotNine1(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            bool foundRotation = false;

            for (int i = 0; i < b.Length; i++)
            {
                string rotation = b.Substring(i) + b.Substring(0, i);
                if (rotation.Equals(a))
                {
                    foundRotation = true;
                    break;
                }
            }

            return foundRotation;
        }

        public bool OneDotNine2(string a, string b)
        {
            return (b + b).Contains(a);
        }
    }
}
