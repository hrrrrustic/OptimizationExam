using System;
using System.Threading.Channels;

namespace OptimizationExam
{
    class Program
    {
        static void Main(string[] args)
        {
            /*double[,] a = new Double[3,3];
            a[0, 0] = 2;
            a[0, 1] = 1;
            a[0, 2] = -3;
            a[1, 0] = 1;
            a[1, 1] = 2;
            a[1, 2] = 1;
            a[2, 0] = 3;
            a[2, 1] = -2;
            a[2, 2] = 2;

            double[,] b = new Double[3, 1];
            b[0, 0] = 4;
            b[1, 0] = 5;
            b[2, 0] = -1;

            var aMatrix = new Matrix(a);
            var bMatrix = new Matrix(b);*/
            var matrix = Matrix.GetRandomWithDiagonalSum(4);
            Console.WriteLine(matrix.ToString());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(matrix.GetInverseMatrix().ToString());

            Console.WriteLine("Matrix with diagonal sum, n and total error");
            for (int n = 2; n < 30; n++)
            {
                var a = Matrix.GetRandomWithDiagonalSum(n);
                var b = a.LUDecompose();
                Double[,] c = new double[n, n];
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < n; ++k)
                            c[i, j] += b.L[i, k] * b.U[k, j];
                    }
                }

                Console.WriteLine($"{n} {GetAvgMatrixDifference(n, a, new Matrix(c)):E}");
            }
            Console.WriteLine("\nHilbert Matrix, n and total error");
            for (int n = 2; n < 30; n++)
            {
                var a = Matrix.GetHilbertMatrix(n);
                var b = a.LUDecompose();
                Double[,] c = new double[n, n];
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < n; ++k)
                            c[i, j] += b.L[i, k] * b.U[k, j];
                    }
                }

                Console.WriteLine($"{n} {GetAvgMatrixDifference(n, a, new Matrix(c)):E}");
            }
        }

        static double GetAvgMatrixDifference(int n, Matrix a, Matrix b)
        {
            double ans = 0.0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ans += Math.Abs(a[i, j] - b[i, j]);
                }
            }

            return ans;
        }
    }
}
