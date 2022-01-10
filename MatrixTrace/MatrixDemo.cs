using System;

namespace MatrixTraceNS
{
    public class MatrixDemo
    {
        private const string EnterDimensionsOfMatrix = "Enter the dimensions of the matrix: ";
        private const string IncorrectInputOfDimension = "Incorrect input of dimension!";
        public const string DimensionOfLines = "lines";
        public const string DimensionOfColumns = "columns";
        private const int InvalidDimension = -1;

        public static void DemoPlay()
        {
            Console.WriteLine(EnterDimensionsOfMatrix);

            try
            {
                Matrix matrix = new Matrix(EnterDimension(DimensionOfLines), EnterDimension(DimensionOfColumns));
                matrix.ShowConsole();
                Console.WriteLine($"\n\nMatrix trace is {matrix.Trace}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static int ValidatingDimension(string possibleDimension)
        {
            return Int32.TryParse(possibleDimension, out int dimesion) ? dimesion : InvalidDimension;
        }

        private static int EnterDimension(string dimension)
        {
            Console.Write($"Number of {dimension}: ");
            int dimensionValue = ValidatingDimension(Console.ReadLine());

            if (dimensionValue == InvalidDimension)
            {
                throw new ArgumentException(IncorrectInputOfDimension);
            }

            return dimensionValue;
        }
    }
}