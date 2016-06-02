using System;

namespace Strings
{
    // Rotate Matrix - Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes,
    // write a method to rotate the image by 90 degrees. Can you do this in place?
    public class OneDotSeven
    {
        public static void OneDotSeven1()
        {
            Console.WriteLine("Performing algorithm 1 for Question 1.7...");

            int[,] matrix = CreateRandomMatrix();

            Console.WriteLine("\nOriginal Matrix");
            PrintMatrix(matrix);

            int[,] rotated = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for(int row = 0; row < rotated.GetLength(0); row++)
            {
                for(int col = 0; col < rotated.GetLength(1); col++)
                {
                    rotated[row, col] = matrix[Math.Abs(col - rotated.GetLength(1)) - 1, row];
                }
            }

            Console.WriteLine("\nRotated Matrix");
            PrintMatrix(rotated);
        }

        // This is the method the book uses, which has the advantage in that it uses less memory.
        // It simply goes layer by layer (the first layer being the entire outside for example, the
        // second layer being the next square layer inside that), moving the top layer to the right,
        // the right to the bottom, and so on, one slot at a time (using an offset). This allows you
        // to make the swap in place (with no additional memory needed).
        public static void OneDotSeven2()
        {
            Console.WriteLine("Performing algorithm 2 for Question 1.7...");

            int[,] matrix = CreateRandomMatrix();

            Console.WriteLine("\nOriginal Matrix");
            PrintMatrix(matrix);

            int n = matrix.GetLength(0);
            for(int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for(int i = first; i < last; i++)
                {
                    int offset = i - first;

                    int top = matrix[first, i];

                    matrix[first, i] = matrix[last - offset, first];
                    matrix[last - offset, first] = matrix[last, last - offset];
                    matrix[last, last - offset] = matrix[i, last];
                    matrix[i, last] = top;
                }
            }

            Console.WriteLine("\nRotated Matrix");
            PrintMatrix(matrix);
        }

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
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("|");
                for(int col = 0; col < matrix.GetLength(1); col++)
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
