using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter2
{
    public static class LinkedListAlgorithms
    {
        public static Chapter2Node CreateIntLinkedList(int size = 100, int max = 100)
        {
            Random r = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);

            Chapter2Node head = new Chapter2Node(r.Next(0, max));
            Chapter2Node current = head;

            for(int i = 1; i < size; i++)
            {
                current.Next = new Chapter2Node(r.Next(0, max));
                current = current.Next;
            }

            return head;
        }

        public static void PrintLinkedList(Chapter2Node head)
        {
            Chapter2Node current = head;

            int count = 0;

            Console.WriteLine("Node {0}: {1}", count, current.Data);

            while (current.Next != null)
            {
                count++;
                Console.WriteLine("Node {0}: {1}", count, current.Next.Data);
                current = current.Next;
            }
        }

        public static Chapter2Node ReverseLinkedList(Chapter2Node head)
        {
            Chapter2Node prev = null;
            Chapter2Node current = head.CloneLinkedList();
            Chapter2Node next = current.Next;
            Chapter2Node retval = null;
            
            while(current != null)
            {
                current.Next = prev;
                prev = current;
                current = next;

                if(current != null)
                {
                    next = current.Next;
                    retval = current;
                }
            }

            return retval;
        }

        public static int GetLength(Chapter2Node head)
        {
            int count = 1;
            while (head.Next != null)
            {
                head = head.Next;
                count++;
            }

            return count;
        }
    }
}
