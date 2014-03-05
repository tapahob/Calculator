using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Operations
{
    public class OpenParenthesis : IOperation
    {
        public char Symbol { get { return '('; } }
        public int Priority { get { return 1; } }
        public void Execute(IRPNCalculator calc)
        {
            calc.RPNStack.Push(Symbol);
        }
    }
}
