using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WpfApp.Models
{
    public class MyFrac : IMyNumber<MyFrac>
    {
        public BigInteger Nom { get; }
        public BigInteger Denom { get; }
        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
                throw new DivideByZeroException();

            if (denom < 0)
            {
                nom = -nom;
                denom = -denom;
            }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(nom), denom);
            Nom = nom / gcd;
            Denom = denom / gcd;
        }
        public MyFrac Add(MyFrac that) => new MyFrac(Nom * that.Denom + that.Nom * Denom, Denom * that.Denom);
        public MyFrac Subtract(MyFrac that) => new MyFrac(Nom * that.Denom - that.Nom * Denom, Denom * that.Denom);
        public MyFrac Multiply(MyFrac that) => new MyFrac(Nom * that.Nom, Denom * that.Denom);
        public MyFrac Divide(MyFrac that) => new MyFrac(Nom * that.Denom, Denom * that.Nom);
    }
}
