
using System.Reflection;

namespace XCalculatorLib
{
    public interface ICalculatorModule
    {
        Assembly Assembly
        {
            get;
        }

        ICalculatorAssemblyInfo AssemblyInfo
        {
            get;
        }

        ICalculatorFunction Function
        {
            get;
        }
    }
}
