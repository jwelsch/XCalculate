using System.Reflection;

namespace ExtensionLib
{
    public interface IExtensionAssembly
    {
        Assembly Assembly
        {
            get;
        }
    }
}
