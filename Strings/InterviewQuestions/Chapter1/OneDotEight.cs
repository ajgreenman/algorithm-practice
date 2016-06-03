using InterviewQuestions.Infrastructure;
using System;
using System.Collections.Generic;

namespace InterviewQuestions.Chapter1
{
    public class OneDotEight : Question
    {
        private static int[,] Matrix;

        public OneDotEight()
            : base(1.8, 0, 3)
        {

        }

        public override void Finisher(bool result, int algorithm, object[] arguments)
        {
            Console.WriteLine("\nZeroed Matrix");
            StringAlgorithms.PrintMatrix(Matrix);

        }

        public void OneDotEight1()
        {
            Matrix = StringAlgorithms.CreateRandomMatrix();

            Console.WriteLine("\nOriginal Matrix");
            StringAlgorithms.PrintMatrix(Matrix);

            List<Point> points = new List<Point>();

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        Point p = new Point(i, j);
                        points.Add(p);
                    }
                }
            }

            foreach (var p in points)
            {
                ZeroOutCol(p.X);
                ZeroOutRow(p.Y);
            }
        }

        // This algorithm is slightly more efficient than my original, in that it uses less space. The boolean arrays
        // will only ever hold 2*N memory, while my Point list may potentially hold up to N*N Points, which is far more memory.
        public void OneDotEight2()
        {
            Matrix = StringAlgorithms.CreateRandomMatrix();

            Console.WriteLine("\nOriginal Matrix");
            StringAlgorithms.PrintMatrix(Matrix);

            bool[] markedCols = new bool[Matrix.GetLength(0)];
            bool[] markedRows = new bool[Matrix.GetLength(1)];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        markedCols[i] = true;
                        markedRows[j] = true;
                    }
                }
            }

            for (int i = 0; i < markedCols.Length; i++)
            {
                if (markedCols[i])
                {
                    ZeroOutCol(i);
                }
            }

            for (int i = 0; i < markedRows.Length; i++)
            {
                if (markedRows[i])
                {
                    ZeroOutRow(i);
                }
            }
        }

        // This algorithm uses little extra memory space to implement. It uses the first row and column to hold zeroes if any
        // other point in the corresponding row/column has a zero (we can do this because if so, then the value in the first
        // row or column will be zeroed out anyway). We must first check if the first row and column have zeroes so that at the
        // end we can zero them out as well.
        public void OneDotEight3()
        {
            Matrix = StringAlgorithms.CreateRandomMatrix();

            Console.WriteLine("\nOriginal Matrix");
            StringAlgorithms.PrintMatrix(Matrix);

            bool colZeroHasZero = false;
            bool rowZeroHasZero = false;

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                if (Matrix[i, 0] == 0)
                {
                    rowZeroHasZero = true;
                    break;
                }
            }

            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                if (Matrix[0, i] == 0)
                {
                    colZeroHasZero = true;
                    break;
                }
            }

            for (int i = 1; i < Matrix.GetLength(0); i++)
            {
                for (int j = 1; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        Matrix[i, 0] = 0;
                        Matrix[0, j] = 0;
                    }
                }
            }

            for (int i = 1; i < Matrix.GetLength(0); i++)
            {
                if (Matrix[i, 0] == 0)
                {
                    ZeroOutCol(i);
                }
            }

            for (int i = 1; i < Matrix.GetLength(1); i++)
            {
                if (Matrix[0, i] == 0)
                {
                    ZeroOutRow(i);
                }
            }

            if (colZeroHasZero)
            {
                ZeroOutCol(0);
            }

            if (rowZeroHasZero)
            {
                ZeroOutRow(0);
            }
        }

        private void ZeroOutRow(int row)
        {
            for (int col = 0; col < Matrix.GetLength(0); col++)
            {
                Matrix[col, row] = 0;
            }
        }

        private void ZeroOutCol(int col)
        {
            for (int row = 0; row < Matrix.GetLength(1); row++)
            {
                Matrix[col, row] = 0;
            }
        }

        private class Point
        {
            private int _x;
            public int X
            {
                get { return _x; }
                set { _x = value; }
            }

            private int _y;
            public int Y
            {
                get { return _y; }
                set { _y = value; }
            }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
