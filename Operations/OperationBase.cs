using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Operations
{
    public abstract class OperationBase : IOperation
    {
        public abstract char Symbol { get; }
        public abstract int Priority { get; }

        protected void PutOperation(IRPNCalculator calc)
        {
            if (calc.IsCalculating)
                return;

            var stack = calc.RPNStack;

            if (stack.Count == 0)
            {
                stack.Push(Symbol);
                return;
            }
            var currentOperation = calc.Operations[stack.Peek()];
            if (currentOperation == null)
                return;
            if (currentOperation.Priority < Priority)
                stack.Push(Symbol);
            else
            {
                for (var op = calc.Operations[stack.Peek()]; stack.Count > 0 && op != null && op.Priority >= Priority; calc.RPNResult += stack.Pop());
                stack.Push(Symbol);
            }
        }


        public virtual void Execute(IRPNCalculator irpnCalculator)
        {
            PutOperation(irpnCalculator);
        }
    }
}
