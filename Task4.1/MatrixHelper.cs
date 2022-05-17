using System;

namespace Task4._1
{
    public delegate T ElementsSum<T>(T val1, T val2);

    public static class MatrixHelper
    {
        public static Matrix<T> Sum<T>(this Matrix<T> m1, Matrix<T> m2, ElementsSum<T> getSum)
        {
            m1 ??= new Matrix<T>(0);
            m2 ??= new Matrix<T>(0);

            var maxSize = Math.Max(m1.Size, m2.Size);
            var newMatrix = new Matrix<T>(maxSize);

            for (var i = 0; i < maxSize; i++)
            {
                newMatrix[i,i] = getSum(m1[i, i],m2[i, i]);
            }

            return newMatrix;
        }

        public static int Int(int a, int b) => a + b;

        public static string Str(string a, string b) => a + " " + b;

        public static double Double(double a, double b) => a + b;
    }
}
