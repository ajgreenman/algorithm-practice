using System;

namespace Strings
{
    public static class OneDotNine
    {
        public static void OneDotNine1(string a, string b)
        {
            Console.WriteLine("Performing algorithm 1 of Question 1.9...");

            if(a.Length != b.Length)
            {
                Console.WriteLine("\"{0}\" is not a rotation of \"{1}.\"", b, a);
                return;
            }

            bool foundRotation = false;

            for(int i = 0; i < b.Length; i++)
            {
                string rotation = b.Substring(i) + b.Substring(0, i);
                if(rotation.Equals(a))
                {
                    foundRotation = true;
                    break;
                }
            }

            if(foundRotation)
            {
                Console.WriteLine("\"{0}\" is a rotation of \"{1}\".", b, a);
            }
            else
            {
                Console.WriteLine("\"{0}\" is not a rotation of \"{1}.\"", b, a);
            }
        }

        public static void OneDotNine2(string a, string b)
        {
            Console.WriteLine("Performing algorithm 2 of Question 1.9...");

            string toCheck = b + b;

            if (toCheck.Contains(a))
            {
                Console.WriteLine("\"{0}\" is a rotation of \"{1}\".", b, a);
            }
            else
            {
                Console.WriteLine("\"{0}\" is not a rotation of \"{1}.\"", b, a);
            }
        }
    }
}
