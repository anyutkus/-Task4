using System;
using RationalFraction;

namespace Main
{
    class Program
    {
        static void Main()
        {
            var num = new RationalNumber(-2, 6);
            var num2 = new RationalNumber(7, 9);
            Console.WriteLine(num.ToString());
            Console.WriteLine(num2.ToString());
            var num3 = num + num2;
            Console.WriteLine(num3.ToString());
            var num4 = num - num2;
            Console.WriteLine(num4.ToString());
            var num5 = num3 * num2;
            var num6 = num / num2;
            Console.WriteLine(num5.ToString());
            Console.WriteLine(num6.ToString());
            Console.WriteLine(num4.CompareTo(num));

            double a = (double)num;
            Console.WriteLine(a);

            RationalNumber n = 6;
            Console.WriteLine(n.ToString());
        }
    }
}
