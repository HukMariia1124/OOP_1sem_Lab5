using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab5_WpfApp.Models
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        public BigInteger Num { get; private set; }
        public BigInteger Denom { get; private set; }
        public MyFrac() : this(BigInteger.Zero, BigInteger.One) {}
        public MyFrac(MyFrac other)
        {
            Num = other.Num;
            Denom = other.Denom;
        }
        public MyFrac(BigInteger num, BigInteger denom)
        {
            Check(num, denom);
        }
        public MyFrac(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("Empty string");

            s = s.Trim();
            BigInteger num;
            BigInteger denom;

            if (s.Contains(' '))
            {
                var parts = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2) throw new ArgumentException("Invalid mixed fraction");

                if (!BigInteger.TryParse(parts[0], out BigInteger whole)) throw new ArgumentException("Invalid whole part");

                var fracParts = parts[1].Split('/');
                if (fracParts.Length != 2) throw new ArgumentException("Invalid fraction part");

                if (!BigInteger.TryParse(fracParts[0], out BigInteger fNum)) throw new ArgumentException("Invalid numerator");
                if (!BigInteger.TryParse(fracParts[1], out BigInteger fDenom)) throw new ArgumentException("Invalid denominator");

                BigInteger absWhole = BigInteger.Abs(whole);
                num = absWhole * fDenom + fNum;
                denom = fDenom;

                if (whole < 0 || (whole == 0 && parts[0][0]=='-'))
                {
                    num = -num;
                }
            }
            else if (s.Contains('/'))
            {
                var parts = s.Split('/');
                if (parts.Length != 2) throw new ArgumentException("Invalid fraction");

                if (!BigInteger.TryParse(parts[0], out num)) throw new ArgumentException("Invalid numerator");
                if (!BigInteger.TryParse(parts[1], out denom)) throw new ArgumentException("Invalid denominator");
            }
            else
            {
                if (!BigInteger.TryParse(s, out num)) throw new ArgumentException("Invalid integer");
                denom = 1;
            }
            Check(num, denom);
        }
        private void Check(BigInteger num, BigInteger denom)
        {
            if (denom == 0)
                throw new DivideByZeroException();

            if (denom < 0)
            {
                num = -num;
                denom = -denom;
            }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(num), denom);
            Num = num / gcd;
            Denom = denom / gcd;
        }
        public MyFrac Add(MyFrac that) => new MyFrac(Num * that.Denom + that.Num * Denom, Denom * that.Denom);
        public MyFrac Subtract(MyFrac that) => new MyFrac(Num * that.Denom - that.Num * Denom, Denom * that.Denom);
        public MyFrac Multiply(MyFrac that) => new MyFrac(Num * that.Num, Denom * that.Denom);
        public MyFrac Divide(MyFrac that) => new MyFrac(Num * that.Denom, Denom * that.Num);
        public override string ToString()
        {
            if (Num == 0) return "0";
            if (Denom == 1) return Num.ToString();

            BigInteger absNom = BigInteger.Abs(Num);
            BigInteger wholeNum = absNom / Denom;
            BigInteger RemNom = absNom % Denom;

            if (wholeNum == 0)
                return $"{Num}/{Denom}";
            else
            {
                string sign = Num < 0 ? "-" : "";
                return $"{sign}{wholeNum} {RemNom}/{Denom}";
            }
        }

        public int CompareTo(MyFrac other)
        {
            BigInteger val1 = Num * other.Denom;
            BigInteger val2 = other.Num * Denom;
            return val1.CompareTo(val2);
        }


        public static MyFrac operator +(MyFrac f1, MyFrac f2) => f1.Add(f2);
        public static MyFrac operator -(MyFrac f1, MyFrac f2) => f1.Subtract(f2);
        public static MyFrac operator *(MyFrac f1, MyFrac f2) => f1.Multiply(f2);
        public static MyFrac operator /(MyFrac f1, MyFrac f2) => f1.Divide(f2);
        public static MyFrac operator -(MyFrac f1) => new MyFrac(-f1.Num, f1.Denom);
    }
}
