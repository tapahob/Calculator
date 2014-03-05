namespace Interfaces
{
    public interface IOperation
    {
        char Symbol { get; }
        int Priority { get; }
        void Execute(IRPNCalculator irpnCalculator);
    }
}
