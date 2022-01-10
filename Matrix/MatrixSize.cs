using System;

namespace MatrixTraceNS
{
    public readonly struct MatrixSize
    {
        public const string ExceptionMessage = "Columns or Lines can't be less than 0";
        public int Lines { get; }
        public int Columns { get; }
        public int[,] Elements { get; }

        public MatrixSize(int lines, int columns, int minValue, int maxValue)
        {
            try
            {
                this.Lines = lines;
                this.Columns = columns;
                this.Elements = new int[lines, columns];
                Random rnd = new Random();

                for (int l = 0; l < lines; l++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        this.Elements[l, c] = rnd.Next(minValue, maxValue);
                    }
                }
            }
            catch
            {
                throw new ArgumentException(ExceptionMessage);
            }
        }
    }
}