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
            this.nom = nom;
            this.denom = denom;
        }
        public MyFrac Add(MyFrac that) => new MyFrac(nom * that.denom + that.nom * denom, denom * that.denom);
        public MyFrac Subtract(MyFrac that) => new MyFrac(nom * that.denom + that.nom * denom, denom * that.denom);
        public MyFrac Multiply(MyFrac that) => new MyFrac(nom * that.denom + that.nom * denom, denom * that.denom);
        public MyFrac Divide(MyFrac that) => new MyFrac(nom * that.denom + that.nom * denom, denom * that.denom);
    }
}
