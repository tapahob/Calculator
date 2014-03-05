using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Operations
{
    /// <summary>
    /// Операция вычетания. Достает из стэка 2 значения и вычетает из второго первое,
    /// так как для вычетания важен порядок операндов, а из стэка они достаются в обратном порядке
    /// </summary>
    public class Subtraction : OperationBase
    {
        public override char Symbol { get { return '-'; } }
        public override int Priority { get { return 2; } }
        public override void Execute(IRPNCalculator calc)
        {
            base.Execute(calc);
            if (calc == null || calc.CalcStack.Count < 2)
                return;
            var val1 = calc.CalcStack.Pop();
            var val2 = calc.CalcStack.Pop();
            calc.CalcStack.Push(val2-val1);
        }
    }
}
