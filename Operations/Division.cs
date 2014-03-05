using Interfaces;

namespace Operations
{
    /// <summary>
    /// Операция деления. Достает из стэка 2 значения и делит второе на первое,
    /// так как для деления важен порядок операндов, а из стэка они достаются в обратном порядке
    /// </summary>
    public class Division : OperationBase
    {
        public override char Symbol { get { return '/'; } }
        public override int Priority { get { return 3; } }
        public override void Execute(IRPNCalculator calc)
        {
            base.Execute(calc);
            if (calc == null || calc.CalcStack.Count < 2)
                return;
            var val1 = calc.CalcStack.Pop();
            var val2 = calc.CalcStack.Pop();
            if (val1 == 0)
                calc.CalcStack.Push(0);
            else
                calc.CalcStack.Push(val2/val1);
        }
    }
}
