
using System.Reflection;

namespace XCalculateLib
{
    public class Module : IModule
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
