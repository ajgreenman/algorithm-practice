using InterviewQuestions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter2
{
    public class TwoDotSix : Question
    {
        private Chapter2Node _head;

        public TwoDotSix()
            : base(2.6, 0, 1)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            if (result)
            {
                Console.WriteLine("Algorithm {0}: Is palindrome.", algorithm);
            }
            else
            {
                Console.WriteLine("Algorithm {0}: Is not palindrome.", algorithm);
            }
        }

        public bool TwoDotSix1()
        {
            _head = LinkedListAlgorithms.CreateIntLinkedList(10, 2);
            LinkedListAlgorithms.PrintLinkedList(_head);

            Chapter2Node reversed = LinkedListAlgorithms.ReverseLinkedList(_head);

            Chapter2Node current = _head;
            while(current != null)
            {
                if(current.Data != reversed.Data)
                {
                    return false;
                }
                current = current.Next;
                reversed = reversed.Next;
            }

            return true;
        }
    }
}
