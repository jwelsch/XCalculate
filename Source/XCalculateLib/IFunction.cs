
namespace XCalculateLib
{
    public interface IFunction
    {
        IFunctionInfo FunctionInfo
        {
            get;
        }

        IValue Calculate(PhaseHandler phaseHandler);
    }
}
