using System;

namespace ConsoleApp1
{
    public readonly struct Fraction
    {
        private readonly int num;
        private readonly int den;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
            }
            num = numerator;
            den = denominator;
        }

        // public static обязательно для operator
        public static Fraction operator +(Fraction a) => a;

        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);
        // в скобках указывается, что складываются объекты этих классов
        public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.num + b.num, a.den + b.den);

        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.num * b.num, a.den * b.den);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.num == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.num * b.den, a.den * b.num);
        }

        public override string ToString() => $"{num} / {den}";
    }

    class Operator
    {
        public void Run() 
        {
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            var op1 = -a;
            var op2 = a + b;
            var op3 = a - b;
            var op4 = a * b;
            var op5 = a / b;
            //var op6 = a + 1;
            var op6 = a + a;
        }
    }
}
