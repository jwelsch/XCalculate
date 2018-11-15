
namespace XCalculateLib
{
    public interface IFunction
    {
        IFunctionInfo FunctionInfo
        {
            get;
        }

        IPhase Calculate(IPhaseTransition transition = null);

        IValue[] CurrentResult
        {
            get;
        }
    }
}
