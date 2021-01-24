using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace OptimizationExam
{
    public enum CompressType
    {
        Row = 1,
        Column = 2
    }

    public class CompressedSparseMatrix
    {
        private readonly double[] _items;
        private readonly int[] _positions;
        private readonly int[] _ind;
        private readonly int _matrixLength;
        private readonly CompressType _type;
        public CompressedSparseMatrix(ICollection<Double> items, ICollection<int> positions, ICollection<int> ind, Int32 matrixLength, CompressType type)
        {
            _matrixLength = matrixLength;
            _type = type;
            _items = items.ToArray();
            _positions = positions.ToArray();
            _ind = ind.ToArray();
        }

        public Matrix ToTableMatrix()
        {
            Double[,] matrix = new Double[_matrixLength, _matrixLength];
            Action<int, int, double> matrixItemSetter = _type is CompressType.Row ? 
                (i, j, value) => matrix[i, j] = value : 
                (i, j, value) => matrix[j, i] = value;

            for (int i = 0; i < _ind.Length - 1; i++)
                for (int j = _ind[i]; j < _ind[i + 1] + 1; j++)
                    matrixItemSetter.Invoke(i, _positions[j - 1], _items[j - 1]);

            return new Matrix(matrix);
        }

        public override String ToString()
        {
            return ToTableMatrix().ToString();
        }
    }
}