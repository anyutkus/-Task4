﻿using System;
using MatrixClass;
using MatrixExtention;

namespace Program
{
    class Program
    {
        static void Main()
        {
            var m = new Matrix<int>(3);
            var m2 = new Matrix<int>(3);

            MatrixTracker<int> m1Track = new(m);

            m[0, 0] = 2;
            m[0, 0] = 4;

            m1Track.Undo();

            m2[1, 1] = 123;

            ElementsSum<int> intSum = MatrixHelper.Int;

            Console.WriteLine(m.ToString());
            Console.WriteLine(m2.ToString());

            Matrix<int> m3 = m.Sum(m2, intSum);

            Console.WriteLine(m3.ToString());

            MatrixTracker<int> m3Track = new(m3);

            m3[2, 2] = 100;

            Console.WriteLine(m3.ToString());
            m3Track.Undo();
            Console.WriteLine(m3.ToString());
        }
    }
}
