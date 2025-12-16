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
        public BigInteger Re { get; }
        public BigInteger Im { get; }
        public MyComplex(BigInteger re, BigInteger im)
        {
            Re = re;
            Im = im;
        }
        public MyComplex Add(MyComplex that) => new MyComplex(Re + that.Re, Im + that.Im);
        public MyComplex Subtract(MyComplex that) => new MyComplex(Re - that.Re, Im - that.Im);
        public MyComplex Multiply(MyComplex that) => new MyComplex(Re * that.Re - Im * that.Im, Re * that.Im + Im * that.Re);
        public MyComplex Divide(MyComplex that)
        {
            BigInteger denom = that.Re * that.Re + that.Im * that.Im;
            if (denom == 0)
                throw new DivideByZeroException();

            return new MyComplex(
                (Re * that.Re + Im * that.Im) / denom,
                (Im * that.Re - Re * that.Im) / denom
            );
        }
    }
}
