using System;

namespace OptimizationExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = Matrix.GetRandomWithDiagonalSum(4);
            Console.WriteLine(matrix.ToString());
            Console.WriteLine();
            Console.WriteLine();
            var lu = matrix.LUDecompose();
            Console.WriteLine(lu.U.ToString());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(lu.L.ToString());
        }
    }
}
