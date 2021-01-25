using System;
using System.Threading.Channels;

namespace OptimizationExam
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] a = new Double[3,3];
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
            var bMatrix = new Matrix(b);
            MatrixEquationSolver.SolveAxEqualsB(aMatrix, bMatrix);
            var matrix = Matrix.GetRandomWithDiagonalSum(4);
            Console.WriteLine(matrix.ToString());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(matrix.ToSparseRowFormat().ToString());
        }
    }
}
