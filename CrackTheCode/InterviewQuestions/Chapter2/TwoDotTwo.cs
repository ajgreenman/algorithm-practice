using InterviewQuestions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter2
{
    public class TwoDotTwo : Question
    {
        private struct Bucket
        {
            public int K, Value;
            public Bucket(int k , int value)
            {
                K = k;
                Value = value;
            }
        }

        public TwoDotTwo()
            : base(2.2, 1, 3)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            // Do nothing.
        }
        
        // This algorithm goes through the whole linked list to get a size, then goes through it again until
        // it finds the element at position {size - k}. This algorithm at takes O(N) time.
        public void TwoDotTwo1(string value)
        {
            int k = Convert.ToInt32(value);
            Chapter2Node head = LinkedListAlgorithms.CreateIntLinkedList(100, 10);
            LinkedListAlgorithms.PrintLinkedList(head);

            int count = 1;
            Chapter2Node current = head;
            while(current.Next != null)
            {
                current = current.Next;
                count++;
            }

            current = head;
            while(count > k)
            {
                current = current.Next;
                count--;
            }

            Console.WriteLine("{0} elements from the end: {1}", k, current.Data);
        }

        // This algorithm does something similar to the first, except it counts k elements from the end.
        // This is a recursive solution and takes O(N) time.
        public void TwoDotTwo2(string value)
        {
            int k = Convert.ToInt32(value);
            Chapter2Node head = LinkedListAlgorithms.CreateIntLinkedList(20, 20);
            LinkedListAlgorithms.PrintLinkedList(head);

            Console.WriteLine("{0} elements from the end: {1}", k, TwoDotTwoRecursive(new Bucket(k, 0), head).Value);
        }

        private Bucket TwoDotTwoRecursive(Bucket b, Chapter2Node current)
        {
            if (current.Next != null)
            {
                Bucket check = TwoDotTwoRecursive(new Bucket(b.K, b.Value), current.Next);

                if (check.K != 0)
                {
                    return new Bucket(--check.K, current.Data);
                }

                return check;
            }

            return new Bucket(--b.K, current.Data);
        }

        public void TwoDotTwo3(string value)
        {
            int k = Convert.ToInt32(value);
            Chapter2Node head = LinkedListAlgorithms.CreateIntLinkedList(10, 10);
            LinkedListAlgorithms.PrintLinkedList(head);

            Chapter2Node endNode = head;
            for(int i = 1; i < k; i++)
            {
                if (endNode.Next == null)
                {
                    Console.WriteLine("The linked list is too small.");
                    return;
                }
                endNode = endNode.Next;
            }

            Chapter2Node current = head;
            while(endNode.Next != null)
            {
                endNode = endNode.Next;
                current = current.Next;
            }

            Console.WriteLine("{0} elements from the end: {1}", k, current.Data);
        }
    }
}
