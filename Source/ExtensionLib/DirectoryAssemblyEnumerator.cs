using ExtensionLib;
using System.IO;
using System.Linq;

namespace XCalculateManagerLib
{
    public class DirectoryAssemblyEnumerator : FileAssemblyEnumerator
    {
        private readonly static string AssemblySearchPattern = "*.dll";

        public DirectoryAssemblyEnumerator(params string[] directoryPaths)
            //: base(EnumerateFilePaths(directoryPaths))
            : base(directoryPaths.SelectMany(i => Directory.GetFiles(i, AssemblySearchPattern, SearchOption.AllDirectories)).ToArray())
        {
        }
    }
}
