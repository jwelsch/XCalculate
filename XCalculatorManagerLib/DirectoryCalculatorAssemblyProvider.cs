using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using XCalculatorManagerLib.Interfaces;

namespace XCalculatorManagerLib
{
    public class DirectoryCalculatorAssemblyProvider : ICalculatorAssemblyProvider
    {
        private readonly string[] directoryPaths;

        public DirectoryCalculatorAssemblyProvider(params string[] directoryPaths)
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
                var filePaths = Directory.GetFiles(directoryPath, "*.dll", SearchOption.AllDirectories);

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
