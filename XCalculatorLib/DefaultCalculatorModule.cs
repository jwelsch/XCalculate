
using System.Reflection;

namespace XCalculatorLib
{
    public class DefaultCalculatorModule : ICalculatorModule
    {
        public Assembly Assembly
        {
            get;
            set;
        }

        public ICalculatorAssemblyInfo AssemblyInfo
        {
            get;
            set;
        }

        public ICalculatorFunction Function
        {
            get;
            set;
        }
    }
}
