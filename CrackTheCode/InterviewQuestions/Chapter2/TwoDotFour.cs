using InterviewQuestions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter2
{
    // Partition: Write code to partition a linked list around a value x, such that all nodes
    // less than x come before all nodes greater than or equal to x. If x is contained within
    // the list, the values of x only need to be after the elements less than x (see below).
    // The partition element x can appear anywhere in the "right partition"; it does not need
    // to appear between the left and right partitions.
    // Input: 3 -> 5 -> 8 -> -> 5 -> 10 -> 2 -> 1 [partition = 5]
    // Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5-> 8
    public class TwoDotFour : Question
    {
        public TwoDotFour()
            : base(2.4, 1, 3)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {

        }

        // I'm like 90% sure this works? 
        public void TwoDotFour1(string v)
        {
            int value = Convert.ToInt32(v);
            Chapter2Node head = LinkedListAlgorithms.CreateIntLinkedList(10, 10);

            Console.WriteLine("Before:");
            LinkedListAlgorithms.PrintLinkedList(head);

            Chapter2Node last = head;
            while(last.Next != null)
            {
                last = last.Next;
            }

            Chapter2Node current = head.Next;
            Chapter2Node previous = head;
            while(current.Next != null)
            {
                if (current.Data < value)
                {
                    previous.Next = current.Next;
                    current.Next = head;
                    head = current;
                    current = previous.Next;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
                Console.WriteLine("Step:");
                LinkedListAlgorithms.PrintLinkedList(head);
            }

            if(current.Data < value)
            {
                current.Next = head;
                head = current;
                previous.Next = null;
            }

            Console.WriteLine("After:");
            LinkedListAlgorithms.PrintLinkedList(head);
        }

        // This algorithm is almost assuredly worse than algorithm 1, however I can be sure it works.
        // Turns out this is the solution in the book! Who would have guessed?
        public void TwoDotFour2(string v)
        {
            int value = Convert.ToInt32(v);
            Chapter2Node head = LinkedListAlgorithms.CreateIntLinkedList(10, 10);

            Console.WriteLine("Before:");
            LinkedListAlgorithms.PrintLinkedList(head);

            Chapter2Node smallHead = null;
            Chapter2Node smallCurrent = smallHead;
            Chapter2Node bigHead = null;
            Chapter2Node bigCurrent = bigHead;

            while (head != null)
            {
                if(head.Data < value)
                {
                    if(smallHead == null)
                    {
                        smallHead = new Chapter2Node(head.Data);
                        smallCurrent = smallHead;
                    }
                    else
                    {
                        smallCurrent.Next = new Chapter2Node(head.Data);
                        smallCurrent = smallCurrent.Next;
                    }
                }
                else
                {
                    if(bigHead == null)
                    {
                        bigHead = new Chapter2Node(head.Data);
                        bigCurrent = bigHead;
                    }
                    else
                    {
                        bigCurrent.Next = new Chapter2Node(head.Data);
                        bigCurrent = bigCurrent.Next;
                    }
                }
                head = head.Next;
            }

            head = smallHead;
            smallCurrent.Next = bigHead;

            Console.WriteLine("After:");
            LinkedListAlgorithms.PrintLinkedList(head);
        }

        // This is an alternate solution the big gives two my algorithm 2.
        // It essentially is what I was trying to do in my algorithm 1.
        public void TwoDotFour3(string v)
        {
            int value = Convert.ToInt32(v);
            Chapter2Node node = LinkedListAlgorithms.CreateIntLinkedList(10, 10);

            Console.WriteLine("Before:");
            LinkedListAlgorithms.PrintLinkedList(node);

            Chapter2Node head = node;
            Chapter2Node tail = node;

            while(node != null)
            {
                Chapter2Node next = node.Next;
                if(node.Data < value)
                {
                    node.Next = head;
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    tail = node;
                }
                node = next;
            }
            tail.Next = null;

            Console.WriteLine("After:");
            LinkedListAlgorithms.PrintLinkedList(head);
        }
    }
}
