using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home5
{
    internal class Calculator : ICalculator
    {
        public event EventHandler<EventArgs> GetResult;
        
        public int result = 0;
        private Stack<int> Results = new Stack<int>(); //создали стек

        public void Divide(int value)
        {
            Results.Push(result);
            result /= value;
            RaisEvent();
            
        }

        public void Multiply(int value)
        {
            Results.Push(result);
            result *= value;
            RaisEvent();
            
        }

        public void Substract(int value)
        {
            Results.Push(result);
            result -= value;
            RaisEvent();
            
        }

        public void Sum(int value)
        {
            Results.Push(result);
            result += value;
            RaisEvent();
     
        }
        private void RaisEvent()
        {
            GetResult?.Invoke(this, EventArgs.Empty);
        }

        public void CancelLast()
        {
            if (Results.Count > 0)
            {
                result = Results.Pop();
                RaisEvent();
            }
                
            

        }
    }
}
