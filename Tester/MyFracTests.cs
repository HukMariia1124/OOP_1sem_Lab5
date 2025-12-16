using Xunit;
using Lab5_WpfApp.Models;
using System;
using System.Numerics;
using System.Collections.Generic;

namespace Tester
{
    public class MyFracTests
    {
        [Fact]
        public void Constructor_Simplify()
        {
            MyFrac frac = new MyFrac(2, 4);
            Assert.Equal(new BigInteger(1), frac.Num);
            Assert.Equal(new BigInteger(2), frac.Denom);
        }

        [Fact]
        public void Constructor_NegativeDenominator()
        {
            MyFrac frac = new MyFrac(1, -2);
            Assert.Equal(new BigInteger(-1), frac.Num);
            Assert.Equal(new BigInteger(2), frac.Denom);
        }

        [Fact]
        public void Constructor_String()
        {
            MyFrac frac = new MyFrac("1/2");
            Assert.Equal(new BigInteger(1), frac.Num);
            Assert.Equal(new BigInteger(2), frac.Denom);
        }

        [Fact]
        public void Constructor_String_Mixed()
        {
            MyFrac frac = new MyFrac("1 1/2");
            Assert.Equal(new BigInteger(3), frac.Num);
            Assert.Equal(new BigInteger(2), frac.Denom);
        }

        [Fact]
        public void Constructor_String_MixedNegative()
        {
            MyFrac frac = new MyFrac("-1 1/2");
            Assert.Equal(new BigInteger(-3), frac.Num);
            Assert.Equal(new BigInteger(2), frac.Denom);
        }

        [Fact]
        public void Constructor_String_MixedNegativeZero()
        {
            MyFrac frac = new MyFrac("-0 1/2");
            Assert.Equal(new BigInteger(-1), frac.Num);
            Assert.Equal(new BigInteger(2), frac.Denom);
        }

        [Fact]
        public void Constructor_InvalidString()
        {
            Assert.Throws<ArgumentException>(() => new MyFrac("..."));
        }

        [Fact]
        public void Constructor_ZeroDenominator()
        {
            Assert.Throws<DivideByZeroException>(() => new MyFrac(1, 0));
        }



        [Fact]
        public void Add()
        {
            MyFrac f1 = new MyFrac(1, 3);
            MyFrac f2 = new MyFrac(1, 6);
            MyFrac result = f1 + f2;

            Assert.Equal(new BigInteger(1), result.Num);
            Assert.Equal(new BigInteger(2), result.Denom);
        }

        [Fact]
        public void Subtract()
        {
            MyFrac f1 = new MyFrac(1, 2);
            MyFrac f2 = new MyFrac(1, 6);
            MyFrac result = f1 - f2;

            Assert.Equal(new BigInteger(1), result.Num);
            Assert.Equal(new BigInteger(3), result.Denom);
        }

        [Fact]
        public void Multiply()
        {
            MyFrac f1 = new MyFrac(2, 3);
            MyFrac f2 = new MyFrac(3, 4);
            MyFrac result = f1 * f2;

            Assert.Equal(new BigInteger(1), result.Num);
            Assert.Equal(new BigInteger(2), result.Denom);
        }

        [Fact]
        public void Divide()
        {
            MyFrac f1 = new MyFrac(1, 2);
            MyFrac f2 = new MyFrac(1, 3);
            MyFrac result = f1 / f2;

            Assert.Equal(new BigInteger(3), result.Num);
            Assert.Equal(new BigInteger(2), result.Denom);
        }

        [Fact]
        public void UnaryMinus()
        {
            MyFrac f1 = new MyFrac(1, 2);
            MyFrac result = -f1;

            Assert.Equal(new BigInteger(-1), result.Num);
            Assert.Equal(new BigInteger(2), result.Denom);
        }

        [Fact]
        public void DivideByZero()
        {
            MyFrac f1 = new MyFrac(1, 2);
            MyFrac f2 = new MyFrac(0, 1);

            Assert.Throws<DivideByZeroException>(() => f1.Divide(f2));
        }

        [Fact]
        public void Sort_ShouldSortCorrectly()
        {
            MyFrac[] arr =
            [
                new MyFrac(1, 2),
                new MyFrac(-1, 2),
                new MyFrac(1, 3),
                new MyFrac(0, 1)
            ];

            Array.Sort(arr);

            Assert.Equal(new BigInteger(-1), arr[0].Num);
            Assert.Equal(new BigInteger(0), arr[1].Num);
            Assert.Equal(new BigInteger(1), arr[2].Num);
            Assert.Equal(new BigInteger(3), arr[2].Denom);
            Assert.Equal(new BigInteger(1), arr[3].Num);
            Assert.Equal(new BigInteger(2), arr[3].Denom);
        }
    }
}