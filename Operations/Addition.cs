using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Operations
{
    /// <summary>
    /// Операция сложения. Достает из стэка 2 значения и складывает их. 
    /// </summary>
    public class Addition : OperationBase
    {
        public override char Symbol { get { return '+'; } }
        public override int Priority { get { return 2; } }

        public override void Execute(IRPNCalculator calc)
        {
            base.Execute(calc);
            if (calc == null || calc.CalcStack.Count < 2)
                return;
            var val = calc.CalcStack.Pop() + calc.CalcStack.Pop();
            calc.CalcStack.Push(val);
        }
    }
}
