using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Chapter1
{
    public static class StringAlgorithms
    {
        public static int[,] CreateRandomMatrix()
        {
            Random r = new Random();
            int size = r.Next(1, 12);
            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = r.Next(0, 50);
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("|");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < 10)
                    {
                        Console.Write(" 0{0} |", matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(" {0} |", matrix[row, col]);
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
