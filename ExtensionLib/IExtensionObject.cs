
namespace ExtensionLib
{
    public interface IExtensionObject
    {
        IExtensionAssembly ExtensionAssembly
        {
            get;
        }

        object Instance
        {
            get;
        }

        T GetInstanceAs<T>();
    }
}
