
namespace XCalculatorLib
{
    public interface ICalculatorFunction
    {
        ICalculatorFunctionInfo FunctionInfo
        {
            get;
        }

        ICalculatorValue Calculate(PhaseHandler phaseHandler);
    }
}
