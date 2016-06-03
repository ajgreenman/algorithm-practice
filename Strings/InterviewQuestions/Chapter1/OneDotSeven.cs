using InterviewQuestions.Infrastructure;
using System;

namespace InterviewQuestions.Chapter1
{
    public class OneDotSeven : Question
    {
        int[,] _rotated;
        public OneDotSeven()
            : base(1.7, 0, 2)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            Console.WriteLine("\nRotated Matrix");
            StringAlgorithms.PrintMatrix(_rotated);
        }

        public void OneDotSeven1()
        {
            int[,] matrix = StringAlgorithms.CreateRandomMatrix();

            Console.WriteLine("\nOriginal Matrix");
            StringAlgorithms.PrintMatrix(matrix);

            int[,] rotated = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int row = 0; row < rotated.GetLength(0); row++)
            {
                for (int col = 0; col < rotated.GetLength(1); col++)
                {
                    rotated[row, col] = matrix[Math.Abs(col - rotated.GetLength(1)) - 1, row];
                }
            }

            _rotated = rotated;
        }

        // This is the method the book uses, which has the advantage in that it uses less memory.
        // It simply goes layer by layer (the first layer being the entire outside for example, the
        // second layer being the next square layer inside that), moving the top layer to the right,
        // the right to the bottom, and so on, one slot at a time (using an offset). This allows you
        // to make the swap in place (with no additional memory needed).
        public void OneDotSeven2()
        {
            int[,] matrix = StringAlgorithms.CreateRandomMatrix();

            Console.WriteLine("\nOriginal Matrix");
            StringAlgorithms.PrintMatrix(matrix);

            int n = matrix.GetLength(0);
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;

                    int top = matrix[first, i];

                    matrix[first, i] = matrix[last - offset, first];
                    matrix[last - offset, first] = matrix[last, last - offset];
                    matrix[last, last - offset] = matrix[i, last];
                    matrix[i, last] = top;
                }
            }

            _rotated = matrix;
        }
    }
}
