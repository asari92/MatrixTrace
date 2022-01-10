using System;

namespace MatrixTraceNS
{
    public class Matrix
    {
        public const int DefaultMinValue = 0;
        public const int DefaultMaxValue = 101;
        public MatrixSize MatrixSize { get; }
        public int Trace { get; }
        public Matrix(int lines, int columns) : this(lines, columns, DefaultMinValue, DefaultMaxValue)
        {
        }
        public Matrix(int lines, int columns, int minValue, int maxValue)
        {
            this.MatrixSize = new MatrixSize(lines, columns, minValue, maxValue);
            this.Trace = GetTrace();
        }

        public void ShowConsole()
        {
            for (int l = 0; l < MatrixSize.Lines; l++)
            {
                Console.WriteLine();

                for (int c = 0; c < MatrixSize.Columns; c++)
                {
                    if (c == l)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write($"{MatrixSize.Elements[l, c]}");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (MatrixSize.Elements[l, c] < 10)
                    {
                        Console.Write("   ");
                    }
                    else if (MatrixSize.Elements[l, c] < 100)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }

        private int GetTrace()
        {
            int matrixTrace = 0;
            int smallerDimension = (MatrixSize.Columns <= MatrixSize.Lines) ? MatrixSize.Columns : MatrixSize.Lines;

            for (int i = 0; i < smallerDimension; i++)
            {
                matrixTrace += MatrixSize.Elements[i, i];
            }

            return matrixTrace;
        }
    }
}
