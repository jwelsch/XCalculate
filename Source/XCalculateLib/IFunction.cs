
namespace XCalculateLib
{
    public interface IFunction
    {
        IFunctionInfo FunctionInfo
        {
            get;
        }

        IValue[] GetInputs();

        IValue[] Calculate(IValue[] inputs);

        //IValue[] Calculate(object[] inputValues);
    }
}
