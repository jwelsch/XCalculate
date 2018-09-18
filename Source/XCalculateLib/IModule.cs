
using System.Reflection;

namespace XCalculateLib
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
