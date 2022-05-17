using System;

namespace Task4._2
{
    sealed class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; init; }//integer
        public int Denominator { get; init; }//natural number

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("denominator == 0");
            }

            if(denominator < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(denominator), "Denominator must be a natural number > 0");
            }

            (Numerator, Denominator) = Simplify(numerator, denominator);
        }

        private static (int, int) Simplify(int numerator, int denominator)
        {
            int n1 = Math.Abs(numerator);
            int n2 = denominator;
            int reminder;
            while (n2 != 0)
            {
                reminder = n1 % n2;
                n1 = n2;
                n2 = reminder;
            }

            return (numerator / n1, denominator / n1);
        }

        public override string ToString()
        {
            if(Denominator == 1)
            {
                return Numerator.ToString();
            }
            else
            {
                return Numerator.ToString() + "/" + Denominator.ToString();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is not RationalNumber)
            {
                return false;
            }

            var number = (RationalNumber)obj;

            if ((this.Numerator == number.Numerator) && (this.Denominator == number.Denominator))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(RationalNumber n2)
        {
            this.NullCheck();
            n2.NullCheck();
            var commonDenominator = this.CommonDenomimator(n2);
            var num1 = this.Numerator * commonDenominator / this.Denominator;
            var num2 = n2.Numerator * commonDenominator / n2.Denominator;
            return num1.CompareTo(num2);
        }

        private int CommonDenomimator(RationalNumber n2)
        {
            var leastCommonMultiple = 1;
            for (var i = 1; i <= this.Denominator * n2.Denominator; i++)
            {
                if ((i % this.Denominator == 0) && (i % n2.Denominator == 0))
                {
                    leastCommonMultiple = i;
                }
            }
            return leastCommonMultiple;
        }

        public static RationalNumber operator +(RationalNumber n1, RationalNumber n2)
        {
            n1.NullCheck();
            n2.NullCheck();
            var newDenominator = n1.CommonDenomimator(n2);
            var newNumerator = (n1.Numerator * newDenominator / n1.Denominator) + (n2.Numerator * newDenominator / n2.Denominator);
            return new RationalNumber(newNumerator,newDenominator);
        }

        public static RationalNumber operator -(RationalNumber n1, RationalNumber n2)
        {
            return n1+n2*(-1);
        }

        public static RationalNumber operator *(RationalNumber n1, RationalNumber n2)
        {
            n1.NullCheck();
            n2.NullCheck();
            return new RationalNumber(n1.Numerator * n2.Numerator, n1.Denominator * n2.Denominator);
        }

        public static RationalNumber operator *(RationalNumber n1, int n2)
        {
            n1.NullCheck();
            return new RationalNumber(n1.Numerator * n2, n1.Denominator);
        }

        public static RationalNumber operator /(RationalNumber n1, RationalNumber n2)
        {
            n1.NullCheck();
            n2.NullCheck();
            var newDenominator = Math.Abs(n1.Denominator * n2.Numerator);
            var newNumerator = n1.Numerator * n2.Denominator;
            if (n2.Numerator<0)
            {
                newNumerator *= -1;

            }
            return new RationalNumber(newNumerator, newDenominator);
        }

        public static explicit operator double(RationalNumber number)
        {
            number.NullCheck();
            return (double)number.Numerator / (double)number.Denominator;
        }

        public static implicit operator RationalNumber(int number)
        {
            return new RationalNumber(number, 1);
        }

        private void NullCheck()
        {
            if (this == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
