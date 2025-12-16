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
        public double Re { get; private set; }
        public double Im { get; private set; }
        public MyComplex() : this(0, 0) { }
        public MyComplex(MyComplex other)
        {
            Re = other.Re;
            Im = other.Im;
        }
        public MyComplex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        public MyComplex(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("Empty string");

            s = s.Replace(" ", "");

            double re = 0;
            double im = 0;

            if (!s.EndsWith("i"))
            {
                if (!double.TryParse(s, out re))
                    throw new ArgumentException("Invalid real number");
                Im = 0;
                Re = re;
                return;
            }

            s = s.TrimEnd('i');

            if (s.Length == 0) { Re = 0; Im = 1; return; }// Input was "i"
            if (s == "+") {Re = 0; Im = 1; return; } // Input was "+i"
            if (s == "-") {Re = 0; Im = -1; return; } // Input was "-i"

            int splitIndex = s.LastIndexOfAny(['+', '-']);

            if (splitIndex <= 0) //Real part is 0
            {
                Re = 0;
                if (!double.TryParse(s, out im))
                    throw new ArgumentException("Invalid imaginary part");
            }
            else
            {
                string rePart = s.Substring(0, splitIndex);
                string imPart = s.Substring(splitIndex);
                
                if (!double.TryParse(rePart, out re))
                    throw new ArgumentException("Invalid real part");
                
                if (imPart == "+" || imPart == "-") //Imaginary part is 1 or -1
                    im = (imPart == "+") ? 1 : -1;
                else
                {
                    if (!double.TryParse(imPart, out im))
                        throw new ArgumentException("Invalid imaginary part");
                }
            }

            Re = re;
            Im = im;
        }
        public MyComplex Add(MyComplex that) => new MyComplex(Re + that.Re, Im + that.Im);
        public MyComplex Subtract(MyComplex that) => new MyComplex(Re - that.Re, Im - that.Im);
        public MyComplex Multiply(MyComplex that) => new MyComplex(Re * that.Re - Im * that.Im, Re * that.Im + Im * that.Re);
        public MyComplex Divide(MyComplex that)
        {
            double denom = that.Re * that.Re + that.Im * that.Im;
            if (denom == 0)
                throw new DivideByZeroException();

            return new MyComplex(
                (Re * that.Re + Im * that.Im) / denom,
                (Im * that.Re - Re * that.Im) / denom
            );
        }
        public override string ToString()
        {
            if (Im == 0) return Re.ToString();
            if (Re == 0)
            {
                if (Im == 1) return "i";
                if (Im == -1) return "-i";
                return $"{Im}i";
            }

            string sign = Im > 0 ? "+" : "-";
            double absIm = double.Abs(Im);

            if (absIm == 1)
                return $"{Re} {sign} i";

            return $"{Re} {sign} {absIm}i";
        }
    }
}
