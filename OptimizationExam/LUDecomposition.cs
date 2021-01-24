using System;

namespace OptimizationExam
{
    public class LUDecomposition
    {
        public readonly Matrix L;
        public readonly Matrix U;

        public LUDecomposition(Matrix l, Matrix u)
        {
            L = l;
            U = u;
        }
    }
}