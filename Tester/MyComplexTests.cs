using Xunit;
using Lab5_WpfApp.Models;
using System;

namespace Tester
{
    public class MyComplexTests
    {
        [Fact]
        public void Constructor_Double_Standard()
        {
            MyComplex c = new MyComplex(1.5, -2.5);
            Assert.Equal(1.5, c.Re);
            Assert.Equal(-2.5, c.Im);
        }

        [Fact]
        public void Constructor_String_Standard()
        {
            MyComplex c1 = new MyComplex("3+4i");
            Assert.Equal(3, c1.Re);
            Assert.Equal(4, c1.Im);
        }

        [Fact]
        public void Constructor_String_WithSpaces()
        {
            MyComplex c = new MyComplex(" 3 + 4 i ");
            Assert.Equal(3, c.Re);
            Assert.Equal(4, c.Im);
        }

        [Fact]
        public void Constructor_String_PureReal()
        {
            MyComplex c = new MyComplex("5,5");
            Assert.Equal(5.5, c.Re);
            Assert.Equal(0, c.Im);
        }

        [Fact]
        public void Constructor_String_PureImaginary()
        {
            MyComplex c1 = new MyComplex("5i");
            Assert.Equal(0, c1.Re);
            Assert.Equal(5, c1.Im);

            MyComplex c2 = new MyComplex("-5i");
            Assert.Equal(0, c2.Re);
            Assert.Equal(-5, c2.Im);
        }

        [Fact]
        public void Constructor_String_ImplicitOne()
        {
            MyComplex c1 = new MyComplex("i");
            Assert.Equal(0, c1.Re);
            Assert.Equal(1, c1.Im);

            MyComplex c2 = new MyComplex("-i");
            Assert.Equal(0, c2.Re);
            Assert.Equal(-1, c2.Im);

            MyComplex c3 = new MyComplex("2+i");
            Assert.Equal(2, c3.Re);
            Assert.Equal(1, c3.Im);

            MyComplex c4 = new MyComplex("2-i");
            Assert.Equal(2, c4.Re);
            Assert.Equal(-1, c4.Im);
        }

        [Fact]
        public void Constructor_String_NegativeRealPart()
        {
            MyComplex c = new MyComplex("-3+4i");
            Assert.Equal(-3, c.Re);
            Assert.Equal(4, c.Im);

            MyComplex c2 = new MyComplex("-3-4i");
            Assert.Equal(-3, c2.Re);
            Assert.Equal(-4, c2.Im);
        }

        [Fact]
        public void Constructor_InvalidString()
        {
            Assert.Throws<ArgumentException>(() => new MyComplex("bla bla"));
            Assert.Throws<ArgumentException>(() => new MyComplex("3++4i"));
            Assert.Throws<ArgumentException>(() => new MyComplex(""));
        }



        [Fact]
        public void Add()
        {
            MyComplex c1 = new MyComplex(1, 2);
            MyComplex c2 = new MyComplex(3, 4);
            MyComplex result = c1 + c2;

            Assert.Equal(4, result.Re);
            Assert.Equal(6, result.Im);
        }

        [Fact]
        public void Subtract()
        {
            MyComplex c1 = new MyComplex(1, 2);
            MyComplex c2 = new MyComplex(3, 4);
            MyComplex result = c1 - c2;

            Assert.Equal(-2, result.Re);
            Assert.Equal(-2, result.Im);
        }

        [Fact]
        public void Multiply()
        {
            MyComplex c1 = new MyComplex(1, 1);
            MyComplex c2 = new MyComplex(1, -1);
            MyComplex result = c1 * c2;

            Assert.Equal(2, result.Re);
            Assert.Equal(0, result.Im);
        }

        [Fact]
        public void Divide()
        {
            MyComplex c1 = new MyComplex(1, 1);
            MyComplex c2 = new MyComplex(1, 1);
            MyComplex result = c1 / c2;

            Assert.Equal(1, result.Re);
            Assert.Equal(0, result.Im);
        }

        [Fact]
        public void UnaryMinus()
        {
            MyComplex c1 = new MyComplex(1, 1);
            MyComplex result = -c1;

            Assert.Equal(-1, result.Re);
            Assert.Equal(-1, result.Im);
        }

        [Fact]
        public void DivideByZero()
        {
            MyComplex c1 = new MyComplex(1, 1);
            MyComplex c2 = new MyComplex(0, 0);

            Assert.Throws<DivideByZeroException>(() => c1.Divide(c2));
        }
    }
}