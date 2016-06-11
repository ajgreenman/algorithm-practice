using System;
using InterviewQuestions.Infrastructure;

namespace InterviewQuestions.Chapter2
{
    // Sum Lists: You have two numbers represented by a linked list, where each node contains a single digit.
    // The digits are stored in reverse order, such that the 1's digit is at the head of the list. Write a
    // function that adds the two numbers and returns the sum as a linked list.
    // Example:
    // Input: (7 -> 1 -> 6) + (5 -> 9 -> 2). 617 + 295.
    // Output: (2 -> 1 -> 9). 912
    // Follow Up:
    // Suppose the digits are stored in forward order. Repeat the above problem.
    public class TwoDotFive : Question
    {
        public TwoDotFive()
            : base(2.5, 0, 3)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            
        }

        public void TwoDotFive1()
        {
            Console.WriteLine("Forwards:");
            Chapter2Node first = LinkedListAlgorithms.CreateIntLinkedList(3, 10);
            Chapter2Node second = LinkedListAlgorithms.CreateIntLinkedList(3, 10);

            LinkedListAlgorithms.PrintLinkedList(first);
            Console.WriteLine("+");
            LinkedListAlgorithms.PrintLinkedList(second);

            Chapter2Node head = SumLinkedLists(first, second);

            Console.WriteLine("=");
            LinkedListAlgorithms.PrintLinkedList(head);
        }

        // This algorithm just reverses the linked list and applies algorithm 1 to it.
        public void TwoDotFive2()
        {
            Console.WriteLine("Backwards:");
            Chapter2Node first = LinkedListAlgorithms.CreateIntLinkedList(3, 10);
            Chapter2Node second = LinkedListAlgorithms.CreateIntLinkedList(4, 10);

            LinkedListAlgorithms.PrintLinkedList(first);
            Console.WriteLine("+");
            LinkedListAlgorithms.PrintLinkedList(second);

            Chapter2Node reversedFirst = LinkedListAlgorithms.ReverseLinkedList(first);
            Chapter2Node reversedSecond = LinkedListAlgorithms.ReverseLinkedList(second);

            Chapter2Node head = SumLinkedLists(reversedFirst, reversedSecond);
            Console.WriteLine("=");
            head = LinkedListAlgorithms.ReverseLinkedList(head);
            LinkedListAlgorithms.PrintLinkedList(head);
        }

        // This is the exact same algorithm as 1 except it uses the recursive version.
        public void TwoDotFive3()
        {
            Console.WriteLine("Forwards:");
            Chapter2Node first = LinkedListAlgorithms.CreateIntLinkedList(3, 10);
            Chapter2Node second = LinkedListAlgorithms.CreateIntLinkedList(3, 10);

            LinkedListAlgorithms.PrintLinkedList(first);
            Console.WriteLine("+");
            LinkedListAlgorithms.PrintLinkedList(second);

            Chapter2Node head = SumLinkedListsRecursively(first, second, 0);

            Console.WriteLine("=");
            LinkedListAlgorithms.PrintLinkedList(head);
        }

        private Chapter2Node SumLinkedLists(Chapter2Node a, Chapter2Node b)
        {
            Chapter2Node head = null;
            Chapter2Node result = null;

            int carry = 0;
            while (a != null || b != null)
            {
                int aData = a != null ? a.Data : 0;
                int bData = b != null ? b.Data : 0;
                int added = (aData + bData + carry);
                carry = added > 9 ? 1 : 0;

                if (result == null)
                {
                    result = new Chapter2Node(added % 10);
                    head = result;
                }
                else
                {
                    result.Next = new Chapter2Node(added % 10);
                    result = result.Next;
                }
                a = a == null ? a : a.Next;
                b = b == null ? b : b.Next;
            }

            if (carry > 0)
            {
                result.Next = new Chapter2Node(carry);
            }

            return head;
        }

        private Chapter2Node SumLinkedListsRecursively(Chapter2Node a, Chapter2Node b, int carry = 0)
        {
            Chapter2Node head = null;
            if(a != null || b != null)
            {
                int aData = a != null ? a.Data : 0;
                int bData = b != null ? b.Data : 0;
                int added = (aData + bData + carry);
                carry = added > 9 ? 1 : 0;
                head = new Chapter2Node(added % 10);
                a = a == null ? a : a.Next;
                b = b == null ? b : b.Next;
            }

            if(a == null && b == null)
            {
                return head;
            }

            head.Next = SumLinkedListsRecursively(a, b, carry);
            return head;
        }
    }
}
