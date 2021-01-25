using System;
using System.Threading.Channels;

namespace OptimizationExam
{
    public class MatrixEquationSolver
    {
        public static Matrix SolveAxEqualsB(Matrix a, Matrix b)
        {
            var lu = a.LUDecompose();
            var res = SolveByGauss(lu.L, b);
            return SolveByGaussReverse(lu.U, res);
        }

        private static Matrix SolveByGauss(Matrix a, Matrix b)
        {
            Double[,] solve = new Double[a.MatrixRowLength, 1];

            for (int i = 0; i < a.MatrixRowLength; i++)
            {
                double currentValue = 0;

                for (int j = 0; j < i; j++)
                    currentValue += a[i, j] * solve[j, 0];

                solve[i, 0] = b[i, 0] - currentValue;
            }

            return new Matrix(solve);
        }

        private static Matrix SolveByGaussReverse(Matrix a, Matrix b)
        {
            Double[,] solve = new Double[a.MatrixRowLength, 1];

            for (int i = a.MatrixRowLength - 1; i > -1; i--)
            {
                double currentValue = 0;
                for (int j = a.MatrixColumnLength - 1; j > i; j--)
                    currentValue += a[i, j] * solve[j, 0];

                solve[i, 0] = (b[i, 0] - currentValue) / a[i, i];
            }

            return new Matrix(solve);
        }
    }
}