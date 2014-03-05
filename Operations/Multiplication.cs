using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Operations
{
    public class Multiplication : OperationBase
    {
        public override char Symbol { get { return '*'; } }
        public override int Priority { get { return 3; } }
        public override void Execute(IRPNCalculator calc)
        {
            base.Execute(calc);
            if (calc == null || calc.CalcStack.Count < 2)
                return;
            calc.CalcStack.Push(calc.CalcStack.Pop() * calc.CalcStack.Pop());
        }
    }
}
