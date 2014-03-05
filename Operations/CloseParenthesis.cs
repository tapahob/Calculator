using Interfaces;

namespace Operations
{
    public class CloseParenthesis : IOperation
    {
        public char Symbol { get { return ')'; } }
        public int Priority { get { return 1; } }
        public void Execute(IRPNCalculator calc)
        {
            // Выталкнуть все операции до открывающей скобки в выходную строку
            while (calc.RPNStack.Peek() != '(')
                calc.RPNResult += calc.RPNStack.Pop();
            // Удаляет открывающую скобку
            calc.RPNStack.Pop();
        }
    }
}
