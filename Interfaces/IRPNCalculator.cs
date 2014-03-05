using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRPNCalculator
    {
        Stack<char> RPNStack { get; }
        Stack<int> CalcStack { get; }
        bool IsCalculating { get; }
        IDictionary<char, IOperation> Operations { get; }
        string RPNResult { get; set; }
    }
}
