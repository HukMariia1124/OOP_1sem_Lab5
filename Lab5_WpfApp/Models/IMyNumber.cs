using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WpfApp.Models
{
    interface IMyNumber<T> where T : IMyNumber<T>
    {
        T Add(T b);
        T Subtract(T b);
        T Multiply(T b);
        T Divide(T b);
    }
}
