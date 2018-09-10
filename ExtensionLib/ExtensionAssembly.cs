using System.Reflection;

namespace ExtensionLib
{
    internal class ExtensionAssembly : IExtensionAssembly
    {
        public Assembly Assembly
        {
            get;
            set;
        }

        public IExtensionAssemblyInfo AssemblyInfo
        {
            get;
            set;
        }
    }
}
