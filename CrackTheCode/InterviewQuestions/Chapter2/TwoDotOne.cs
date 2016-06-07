using InterviewQuestions.Infrastructure;
using System;
using System.Collections.Generic;

namespace InterviewQuestions.Chapter2
{
    public class TwoDotOne : Question
    {
        private Chapter2Node _linkedList;

        public TwoDotOne()
            : base(2.1, 0, 3)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            Console.WriteLine("Algorithm {0} sorted:", algorithm);
            LinkedListAlgorithms.PrintLinkedList(_linkedList);
        }

        public void TwoDotOne1()
        {
            _linkedList = LinkedListAlgorithms.CreateIntLinkedList(10, 10);

            Console.WriteLine("Unsorted:");
            LinkedListAlgorithms.PrintLinkedList(_linkedList);

            HashSet<int> buffer = new HashSet<int>();
            Chapter2Node current = _linkedList;
            buffer.Add(current.Data);
            while(current.Next != null)
            {
                if(!buffer.Contains(current.Next.Data))
                {
                    buffer.Add(current.Next.Data);
                }
                current = current.Next;
            }

            current = _linkedList;
            bool first = true;
            foreach(var key in buffer)
            {
                if(!first)
                {
                    current.Next = new Chapter2Node(key);
                    current = current.Next;
                }
                else
                {
                    first = false;
                }
            }
        }

        // This algorithm is definitely worse in every way than algorithm 1, however the book asked how I would
        // do this without using a buffer, so here it is in all its inefficient glory.
        // And after looking up the solution in the book, this is the correct solution for the no buffer version.
        // It runs in O(N^2) time with O(1) space.
        public void TwoDotOne2()
        {
            _linkedList = LinkedListAlgorithms.CreateIntLinkedList(10, 10);

            Console.WriteLine("Unsorted:");
            LinkedListAlgorithms.PrintLinkedList(_linkedList);

            Chapter2Node outerCurrent = _linkedList;
            while (outerCurrent.Next != null)
            {
                int currentData = outerCurrent.Data;
                Chapter2Node current = outerCurrent;

                while (current.Next != null)
                {
                    if (current.Next.Data == currentData)
                    {
                        current.Next = current.Next.Next;
                    }
                    current = current.Next;

                    if(current == null)
                    {
                        break;
                    }
                }

                if(outerCurrent.Next != null)
                {
                    outerCurrent = outerCurrent.Next;
                }
            }
        }

        // Algorithm 1 requires two passes through the linked list, this algorithm cuts that down to just 1 pass.
        public void TwoDotOne3()
        {
            _linkedList = LinkedListAlgorithms.CreateIntLinkedList(10, 10);

            Console.WriteLine("Unsorted:");
            LinkedListAlgorithms.PrintLinkedList(_linkedList);

            HashSet<int> buffer = new HashSet<int>();
            Chapter2Node current = _linkedList;
            buffer.Add(current.Data);

            while(current.Next != null)
            {
                if(buffer.Contains(current.Next.Data))
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    buffer.Add(current.Next.Data);
                    current = current.Next;
                }
            }
        }
    }
}
