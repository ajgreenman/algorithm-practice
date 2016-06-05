using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter2
{
    public class Chapter2Node
    {
        private int _data;
        public int Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private Chapter2Node _next;
        public Chapter2Node Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public Chapter2Node(int data)
        {
            Data = data;
        }

        public void AppendNode(int data)
        {
            Chapter2Node tail = new Chapter2Node(data);

            Chapter2Node current = this;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = tail;
        }

        public Chapter2Node RemoveNode(Chapter2Node head, int data)
        {
            Chapter2Node current = head;

            if(head.Data == data)
            {
                return head.Next;
            }

            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                    return head;
                }
                current = current.Next;
            }

            return head;
        }
    }
}
