
namespace ExtensionLib
{
    internal class ExtensionObject : IExtensionObject
    {
        public IExtensionAssembly ExtensionAssembly
        {
            get;
            set;
        }

        public object Instance
        {
            get;
            set;
        }

        public T GetInstanceAs<T>()
        {
            return (T)this.Instance;
        }
    }
}
