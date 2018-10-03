
namespace XCalculateLib
{
    public interface IFunction
    {
        IFunctionInfo FunctionInfo
        {
            get;
        }

        //IValue Calculate(PhaseHandler phaseHandler);

        IPhase Calculate(IPhase currentPhase = null);

        IValue[] CurrentResult
        {
            get;
        }
    }
}
