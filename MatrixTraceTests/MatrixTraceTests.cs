using System;
using Xunit;
using MatrixTraceNS;

namespace MatrixTraceTestsNS
{
    public class MatrixTraceTests
    {
        [Theory]
        [InlineData(5, 5, 25)]
        [InlineData(4, 8, 32)]
        [InlineData(10, 8, 80)]
        [InlineData(1, 1, 1)]
        public void CheckMatrixSizeWithValidInput(int columns, int lines, int expected)
        {
            var matrix = new Matrix(lines, columns);
            int actual = matrix.MatrixSize.Elements.GetLength(0) * matrix.MatrixSize.Elements.GetLength(1);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-5, 3)]
        [InlineData(null, 0)]
        public void CheckMatrixSizeWithInvalidInput(int columns, int lines)
        {
            try
            {
                var actual = new Matrix(lines, columns);
            }
            catch (ArgumentException e)
            {
                Assert.Contains(e.Message, MatrixSize.ExceptionMessage);
            }
        }

        [Theory]
        [InlineData(1000, 1000)]
        [InlineData(1, 1)]
        public void CheckMatrixElements(int columns, int lines)
        {
            var matrix = new Matrix(lines, columns);
            bool hasInvalidElement = false;

            foreach (int i in matrix.MatrixSize.Elements)
            {
                if (i < 0 || i > 100)
                {
                    hasInvalidElement = true;
                }
            }

            Assert.False(hasInvalidElement);
        }

        [Theory]
        [InlineData(1000, 1000, 1, 1, 1000)]
        [InlineData(8, 20, 1, 1, 8)]
        [InlineData(60, 30, 1, 1, 30)]
        [InlineData(1, 1, 1, 1, 1)]
        public void CheckMatrixTrace(int lines, int columns, int minValue, int maxValue, int expected)
        {
            var matrix = new Matrix(lines, columns, minValue, maxValue);
            int actual = matrix.Trace;

            Assert.Equal(expected, actual);
        }
    }
}