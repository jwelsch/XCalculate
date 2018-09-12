using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ExtensionLib
{
    public abstract class FileSystemAssemblyEnumerator : IAssemblyEnumerator
    {
        public IEnumerator<Assembly> GetEnumerator()
        {
            var assemblies = this.LoadAssemblies();

            return assemblies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var assemblies = this.LoadAssemblies();

            return assemblies.GetEnumerator();
        }

        protected abstract IEnumerable<Assembly> LoadAssemblies();

    }
}
