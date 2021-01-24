using System;
using System.ComponentModel;
using System.Text;

namespace OptimizationExam
{
    public class Matrix
    {
        private static readonly Random Random = new Random();
        private readonly Double[,] _matrix;

        private int MatrixLength => _matrix.GetLength(0);
        public Matrix(Double[,] matrix)
        {
            _matrix = matrix;
        }
        public Double this[int x, int y] => _matrix[x, y];

        public static Matrix GetHilbertMatrix(int k)
        {
            Double[,] matrix = new Double[k, k];
            for (int i = 1; i < k + 1; i++)
                for (int j = 1; j < k + 1; j++)
                    matrix[i - 1, j - 1] = (double)1 / (i + j - 1);

            return new Matrix(matrix);
        }

        public static Matrix GetRandomWithDiagonalSum(int k)
        {
            Double[,] matrix = new Double[k, k];
            Int32[] sums = new Int32[k];

            for (int i = 1; i < k + 1; i++)
                for (int j = 1; j < k + 1; j++)
                {
                    var val = Random.Next(1, 5);
                    matrix[i - 1, j - 1] = val;

                    if(i != j)
                        sums[i - 1] += val;
                }

            for (int i = 0; i < k; i++)
                matrix[i, i] = sums[i];

            return new Matrix(matrix);
        }

        public LUDecomposition LUDecompose()
        {
            Double[,] l = new Double[MatrixLength, MatrixLength];
            Double[,] u = _matrix.GetCopy();

            for (int i = 0; i < MatrixLength; i++)
                for (int j = i; j < MatrixLength; j++)
                    l[j, i] = _matrix[j, i] / _matrix[i, i];

            for (int i = 1; i < MatrixLength; i++)
            {
                for (int j = i - 1; j < MatrixLength; j++)
                    for (int k = j; k < MatrixLength; k++)
                        l[k, j] = u[k, j] / u[j, j];

                for (int j = i; j < MatrixLength; j++)
                    for (int k = i - 1; k < MatrixLength; k++)
                        u[j, k] = u[j, k] - l[j, i - 1] * u[i - 1, k];
            }

            return new LUDecomposition(new Matrix(l), new Matrix(u));
        }

        public override String ToString()
        {
            var stringBuilder = new StringBuilder(_matrix.Length);
            for (int i = 0; i < MatrixLength; i++)
            {
                for (int j = 0; j < MatrixLength ; j++)
                    stringBuilder.Append(_matrix[i, j]).Append(' ');

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}