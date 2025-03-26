using Xunit;
using FractionCalculator;
using System;

namespace FractionCalculator.Tests
{
    public class FractionTests
    {
        [Fact]
        public void Add_TwoFractions_ReturnsCorrectResult()
        {
            var frac1 = new Fraction(1, 2);
            var frac2 = new Fraction(1, 3);
            var result = frac1.Add(frac2);
            var expected = new Fraction(5, 6); // 1/2 + 1/3 = 5/6
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Subtract_TwoFractions_ReturnsCorrectResult()
        {
            var frac1 = new Fraction(3, 4);
            var frac2 = new Fraction(1, 4);
            var result = frac1.Subtract(frac2);
            var expected = new Fraction(1, 2); // 3/4 - 1/4 = 1/2
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Multiply_TwoFractions_ReturnsCorrectResult()
        {
            var frac1 = new Fraction(2, 3);
            var frac2 = new Fraction(3, 4);
            var result = frac1.Multiply(frac2);
            var expected = new Fraction(1, 2); // 2*3 = 6, 3*4 = 12, 6/12 = 1/2
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_TwoFractions_ReturnsCorrectResult()
        {
            var frac1 = new Fraction(1, 2);
            var frac2 = new Fraction(3, 4);
            var result = frac1.Divide(frac2);
            var expected = new Fraction(2, 3); // (1/2) / (3/4) = (1*4)/(2*3) = 4/6 = 2/3
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivisionByZeroFraction_ThrowsException()
        {
            var frac1 = new Fraction(1, 2);
            var frac2 = new Fraction(0, 1);
            Assert.Throws<DivideByZeroException>(() => frac1.Divide(frac2));
        }
    }
}
