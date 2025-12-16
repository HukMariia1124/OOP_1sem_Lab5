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
        public BigInteger nom { get; }
        public BigInteger denom { get; }
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
            this.nom = nom / gcd;
            this.denom = denom / gcd;
        }
        public MyFrac Add(MyFrac that) => new MyFrac(nom * that.denom + that.nom * denom, denom * that.denom);
        public MyFrac Subtract(MyFrac that) => new MyFrac(nom * that.denom - that.nom * denom, denom * that.denom);
        public MyFrac Multiply(MyFrac that) => new MyFrac(nom * that.nom, denom * that.denom);
        public MyFrac Divide(MyFrac that) => new MyFrac(nom * that.denom, denom * that.nom);
    }
}
