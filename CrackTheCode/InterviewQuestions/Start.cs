using System;
using InterviewQuestions.Infrastructure;

namespace InterviewQuestions
{
    public class Start
    {
        private static string[] Numbers = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };

        public static void Main(string[] args)
        {
            Console.Write("Enter chapter number: ");
            int chapter = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter question number: ");
            int question = Convert.ToInt32(Console.ReadLine());

            string className = Numbers[chapter] + "Dot" + Numbers[question];
            Type classType = Type.GetType("InterviewQuestions.Chapter" + chapter + "." + className);

            if(classType == null)
            {
                throw new Exception("Could not find a suitable class for the chapter and question number you entered.");
            }

            Question q = (Question) Activator.CreateInstance(classType);

            bool again = true;

            while(again)
            {
                Console.WriteLine();
                object[] arguments = new object[q.ArgumentCount];
                for (int i = 0; i < q.ArgumentCount; i++)
                {
                    Console.Write("Enter argument {0}: ", i + 1);
                    arguments[i] = Console.ReadLine();
                }

                for (int i = 1; i <= q.AlgorithmCount; i++)
                {
                    Console.WriteLine("\nPerforming algorithm {0} for Question {1}...", i, q.Number);
                    var method = q.GetType().GetMethod(className + i);

                    bool result;
                    if (method.ReturnType.Name.Equals("Boolean"))
                    {
                        result = (bool) method.Invoke(q, arguments);
                    }
                    else
                    {
                        result = false;
                        method.Invoke(q, arguments);
                    }

                    q.Finisher(result, i, arguments);
                }

                Console.Write("\nGo again (Y/N)? ");
                string answer = Console.ReadLine();
                again = answer.ToUpper().Equals("Y");
            }
        }
    }
}
