using InterviewQuestions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter2
{
    public class TwoDotThree : Question
    {
        public TwoDotThree()
            : base(2.3, 1, 2)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            // Do nothing.
        }

        public void TwoDotThree1(string value)
        {
            int middleNode = Convert.ToInt32(value);
            Chapter2Node head = LinkedListAlgorithms.CreateIntLinkedList(10, 10);

            Console.WriteLine("Before:");
            LinkedListAlgorithms.PrintLinkedList(head);

            Chapter2Node current = head;
            while(current.Next != null)
            {
                if(current.Next.Data == middleNode && current.Next.Next != null)
                {
                    current.Next = current.Next.Next;
                    break;
                }
                current = current.Next;
            }

            Console.WriteLine("After:");
            LinkedListAlgorithms.PrintLinkedList(head);
        }

        // This solves a different problem, one that the book seems to be asking.
        // The first algorithm I think answers the wrong question.
        public void TwoDotThree2(string value)
        {
            int middleNode = Convert.ToInt32(value);
            Chapter2Node head = LinkedListAlgorithms.CreateIntLinkedList(40, 10);

            Console.WriteLine("Before:");
            LinkedListAlgorithms.PrintLinkedList(head);

            Chapter2Node current = head;
            while (current != null)
            {
                if (current.Data == middleNode && current.Next != null)
                {
                    current.Data = current.Next.Data;
                    current.Next = current.Next.Next;
                    break;
                }
                current = current.Next;
            }

            Console.WriteLine("After:");
            LinkedListAlgorithms.PrintLinkedList(head);
        }
    }
}