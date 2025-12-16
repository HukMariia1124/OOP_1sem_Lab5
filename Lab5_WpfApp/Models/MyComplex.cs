using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WpfApp.Models
{
    public class MyComplex: IMyNumber<MyComplex>
    {
        public BigInteger re { get; }
        public BigInteger im { get; }
        public MyComplex(BigInteger re, BigInteger im)
        {
            this.re = re;
            this.im = im;
        }
        public MyComplex Add(MyComplex that) => new MyComplex(re * that.im + that.re * im, im * that.im);
        public MyComplex Subtract(MyComplex that) => new MyComplex(re * that.im + that.re * im, im * that.im);
        public MyComplex Multiply(MyComplex that) => new MyComplex(re * that.im + that.re * im, im * that.im);
        public MyComplex Divide(MyComplex that) => new MyComplex(re * that.im + that.re * im, im * that.im);
    }
}
