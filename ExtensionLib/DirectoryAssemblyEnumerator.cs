using ExtensionLib;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace XCalculatorManagerLib
{
    public class DirectoryAssemblyEnumerator : IAssemblyEnumerator
    {
        private readonly static string AssemblySearchPattern = "*.dll";

        private readonly string[] directoryPaths;

        public DirectoryAssemblyEnumerator(params string[] directoryPaths)
        {
            this.directoryPaths = directoryPaths;
        }

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

        private IEnumerable<Assembly> LoadAssemblies()
        {
            var assemblies = new List<Assembly>();

            foreach (var directoryPath in this.directoryPaths)
            {
                var filePaths = Directory.GetFiles(directoryPath, AssemblySearchPattern, SearchOption.AllDirectories);

                foreach (var filePath in filePaths)
                {
                    var assembly = Assembly.LoadFile(filePath);

                    assemblies.Add(assembly);
                }
            }

            return assemblies;
        }
    }
}
