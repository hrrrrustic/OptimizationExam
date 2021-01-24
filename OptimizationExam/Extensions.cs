using System;

namespace OptimizationExam
{
    public static class Extensions
    {
        public static Double[,] GetCopy(this Double[,] current)
        {
            var newArray = new Double[current.GetLength(0), current.GetLength(1)];
            for (int i = 0; i < current.GetLength(0); i++)
                for (int j = 0; j < current.GetLength(1); j++)
                    newArray[i, j] = current[i, j];

            return newArray;
        }
    }
}