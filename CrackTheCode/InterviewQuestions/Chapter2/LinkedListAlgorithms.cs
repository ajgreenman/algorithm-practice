using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter2
{
    public static class LinkedListAlgorithms
    {
        public static void CreateIntLinkedList(int? size = null)
        {
            Random r = new Random();
            if(size == null)
            {
                size = r.Next(0, 100);
            }


        }
    }
}
