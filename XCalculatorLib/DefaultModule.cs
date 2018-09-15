
using System.Reflection;

namespace XCalculatorLib
{
    public class DefaultModule : IModule
    {
        public Assembly Assembly
        {
            get;
            set;
        }

        public IAssemblyInfo AssemblyInfo
        {
            get;
            set;
        }

        public IFunction Function
        {
            get;
            set;
        }
    }
}
