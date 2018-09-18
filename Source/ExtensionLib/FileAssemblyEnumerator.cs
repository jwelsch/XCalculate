using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ExtensionLib
{
    public class FileAssemblyEnumerator : FileSystemAssemblyEnumerator
    {
        private readonly string[] filePaths;

        public FileAssemblyEnumerator(string[] filePaths)
        {
            this.filePaths = filePaths;
        }

        protected override IEnumerable<Assembly> LoadAssemblies()
        {
            var assemblies = new List<Assembly>();

            foreach (var filePath in this.filePaths)
            {
                var assembly = Assembly.LoadFile(filePath);

                assemblies.Add(assembly);
            }

            return assemblies;
        }
    }
}
