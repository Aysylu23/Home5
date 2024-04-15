using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home5
{
    internal interface ICalculator
    {
        event EventHandler<EventArgs> GetResult;
        void Sum(int value);
        void Substract(int value);
        void Multiply(int value);
        void Divide(int value);
        void CancelLast();

    }
}
