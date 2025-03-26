using System;

namespace FractionCalculator
{
    public class Fraction
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменник не може дорівнювати нулю.");

            // Нормалізація знаку: знаменник завжди додатній
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        // Рекурсивний алгоритм для знаходження НСД
        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public Fraction Add(Fraction other)
        {
            int num = this.Numerator * other.Denominator + other.Numerator * this.Denominator;
            int den = this.Denominator * other.Denominator;
            return new Fraction(num, den);
        }

        public Fraction Subtract(Fraction other)
        {
            int num = this.Numerator * other.Denominator - other.Numerator * this.Denominator;
            int den = this.Denominator * other.Denominator;
            return new Fraction(num, den);
        }

        public Fraction Multiply(Fraction other)
        {
            int num = this.Numerator * other.Numerator;
            int den = this.Denominator * other.Denominator;
            return new Fraction(num, den);
        }

        public Fraction Divide(Fraction other)
        {
            if (other.Numerator == 0)
                throw new DivideByZeroException("Ділення на дріб з чисельником 0 недопустиме.");
            int num = this.Numerator * other.Denominator;
            int den = this.Denominator * other.Numerator;
            return new Fraction(num, den);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
                return this.Numerator == other.Numerator && this.Denominator == other.Denominator;
            return false;
        }

        public override int GetHashCode() => (Numerator, Denominator).GetHashCode();
    }
}
