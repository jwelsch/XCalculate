
using System.Reflection;

namespace XCalculatorLib
{
    public interface IModule
    {
        Assembly Assembly
        {
            get;
        }

        IAssemblyInfo AssemblyInfo
        {
            get;
        }

        IFunction Function
        {
            get;
        }
    }
}
