using System.Collections.Generic;
using XCalculateLib;

namespace XCalculateManagerLib
{
    public interface ICalculatorModuleFactory
    {
        IEnumerable<IModule> CreateFromDirectories(params string[] directoryPaths);

        IEnumerable<IModule> CreateFromFiles(params string[] filePaths);
    }
}
